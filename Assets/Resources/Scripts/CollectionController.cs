using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionController : MonoBehaviour
{
    public ShootingController  shooting;
    public PlayerHealth playerHealth;
    public BombController bombController;
    public PowerUpController powerUpController;

    public int ammoAmount;

    //define what the bonus activate
    public void Collect(GameObject collectable)
    {
        Collectable collectableScript = collectable.GetComponent<Collectable>();

        string collectableType = collectableScript.collectableType;

        if (collectableType == "Ammo")
        {
            shooting.amountAmmo += ammoAmount;
        }
        else if (collectableType == "Shield")
        {
            if (playerHealth.amountShields < 5)
            {
                playerHealth.amountShields++;
            }
        }
        else if (collectableType == "Bomb")
        {
            if (bombController.amountBombs < 5)
            {
                bombController.amountBombs++;
            }
        }
        else if (collectableType == "Berserk")
        {
            powerUpController.ActivateBerserk();
        }
        else if (collectableType == "Laser")
        {
            powerUpController.ActivateLaser();
        }
        else if (collectableType == "MultiShot")
        {
            powerUpController.ActivateMultiShot();
        }

        Destroy(collectable);
    }
}
