using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private bool Hit;
    private float Timer = 0;
    public static bool TimerActive = false;



    private bool PickupHit;

    void Start()
    {
        
    }

    void Update()
    {
        //Debug.Log(Timer);
        if (TimerActive)
        {
            Timer += Time.deltaTime;
            Hit = false;
        }
        else if (!TimerActive)
        {
            Timer = 0;
        }

        Hit = PlayerHealth.isHit;
        ShieldPickup();
    }

    void ShieldPickup()
     {
         if (PickupHit)
         {
            TimerActive = true;
            if (Timer >= 15)
            {
                PickupHit = false;
                TimerActive = false;
            }
         }
     }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            PickupHit = true;
            Destroy(other.gameObject);
        }
    }
}
