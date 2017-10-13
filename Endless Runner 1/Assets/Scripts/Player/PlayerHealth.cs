using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField]
    private float health = 50.0f;
    private bool TimeActive;
    //public static bool PlayerDead = false;
    public static bool isHit = false;

    // Update is called once per frame
    void Update()
    {
        DieMechanic();
        TimeActive = PowerUp.TimerActive;
    }

    void DieMechanic()
    {
        Vector3 relativePoint = transform.InverseTransformPoint(0, -10, 0);
        if (transform.position.y < relativePoint.y)
        {
            Application.LoadLevel(2);
            //PlayerDead = true;
        }
        /*
        else
        {
            PlayerDead = false;
        }
        */
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            //PlayerDead = true;
            Debug.Log("Hit!");
            Application.LoadLevel(2);
        }
        /*
        else
        {
            PlayerDead = false;
        }
        */

    }
}
