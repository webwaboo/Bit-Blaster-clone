using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public GameObject powerUpLaser;
    public GameObject powerUpMultiShot;
    public GameObject powerUpBerserk;
    public GameObject resourceAmmo;
    public GameObject resourceShield;
    public GameObject resourceBomb;
    public float powerUpSpawnChance = 0.1f;

    //spawn random collectable
    public void SpawnRandomCollectable(Transform pos)
    {
        if(Random.value < powerUpSpawnChance)
        {
            SpawnRandomPowerUp(pos);
        }
        else
        {
            SpawnRandomResources(pos);
        }
    }

    //create rng for spawing weapons
    public void SpawnRandomPowerUp(Transform pos)
    {
        float v = Random.value;
        Collectable newCollectable;

        if(v > 0.5f)
        {
            newCollectable = Collectable.CreateMultiShot();
        }else if(v < 0.2f)
        {
            newCollectable= Collectable.CreateBerserk();
        }
        else
        {
            newCollectable= Collectable.CreateLaser();
        }

        //position of spawning is the one from parameter
        newCollectable.gameObject.transform.position = pos.position;
    }

    //create rng for spawing bonus
    public void SpawnRandomResources(Transform pos)
    {
        float v = Random.value;
        Collectable newCollectable;

        if (v >= 0.1f)
        {
            newCollectable = Collectable.CreateAmmo();
        }
        else if (v >= 0.05f)
        {
            newCollectable = Collectable.CreateBomb();
        }
        else
        {
            newCollectable = Collectable.CreateShield();
        }

        //position of spawning is the one from parameter
        newCollectable.gameObject.transform.position = pos.position;
    }
}
