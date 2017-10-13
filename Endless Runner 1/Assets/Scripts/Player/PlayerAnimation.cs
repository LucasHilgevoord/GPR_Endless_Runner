using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    private bool _OnFloor = true;
    
    [SerializeField]
    private Animator anim;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        _OnFloor = PlayerMovement.onFloor;
        if (_OnFloor)
        {
            anim.enabled = true;
            anim.speed = 2.0f;
        }
        else 
        {
            anim.enabled = false;
        }
	}
}
