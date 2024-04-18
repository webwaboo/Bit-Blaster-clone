using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public float basicDuration;
    public bool powerUpActive = true;
    public MultiShot multishot;
    public GameObject laser;
    public GameObject berserk;
    float activeUntilTime = 0f;
    string powerUpType = "multishot";

    // Start is called before the first frame update
    void Start()
    {
        ActivateBerserk();
    }

    // activate power up
    void FixedUpdate()
    {
        //if condition for activatition is right,
        if(powerUpActive && Time.time < activeUntilTime)
        {
            if(powerUpType == "multishot") {
                multishot.ShootRepeating();
            }else if(powerUpType == "laser")
            {
                laser.SetActive(true);
            }else if (powerUpType == "berserk")
            {
                berserk.SetActive(true) ;
            }
        }
        else
        {
            powerUpType = null;
            powerUpActive = false;
        }

        if(powerUpType != "berserk")
        {
            berserk.SetActive(false);
        }
        if(powerUpType != "laser")
        {
            laser.SetActive(false) ;
        }
    }

    public void ActivateMultiShot()
    {
        powerUpActive = true;
        powerUpType = "multishot";
        activeUntilTime = Time.time + basicDuration;
    }

    public void ActivateLaser()
    {
        powerUpActive = true;
        powerUpType = "laser";
        activeUntilTime = Time.time + basicDuration;
    }

    public void ActivateBerserk()
    {
        powerUpActive = true;
        powerUpType = "berserk";
        activeUntilTime = Time.time + basicDuration;
    }
}
