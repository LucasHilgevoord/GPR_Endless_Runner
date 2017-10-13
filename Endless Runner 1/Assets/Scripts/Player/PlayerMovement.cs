using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private float gravity = 14.0f;
    [SerializeField]
    private float jumpForce = 10.0f;


    private CharacterController controller;

    private float gDistance = 1.1f;
    public static bool onFloor = false;
    private float verticalVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Physics.Linecast(transform.position, new Vector3(transform.position.x, transform.position.y - gDistance, transform.position.z)))
        {
            Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - gDistance, transform.position.z), Color.red);
            onFloor = true;
        } 
        else {
            onFloor = false;
            
        }

        if (onFloor)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
        }
        else if(!onFloor)
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        Vector3 moveVector = new Vector3(0, verticalVelocity, 0);
        moveVector.y = verticalVelocity;
        controller.Move(moveVector * Time.deltaTime);

        controller.Move(Vector3.forward * speed * Time.deltaTime);
    }

}
