using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public EnemyMovementController movementController;
    
    //instantiate new enemy from resources prefab
    public static CreateEnemy GetNewPrimitive()
    {
        GameObject enemy = (GameObject)Instantiate(Resources.Load("Prefab/EnemyPrimitive"));
        return enemy.GetComponent<CreateEnemy>();
    }

    //instantiate new enemy from resources prefab
    public static CreateEnemy GetNewSplitter()
    {
        GameObject enemy = (GameObject)Instantiate(Resources.Load("Prefab/EnemyPrimitiveSplitter"));
        return enemy.GetComponent<CreateEnemy>();
    }

    //instantiate new enemy from resources prefab
    public static CreateEnemy GetNewShooting()
    {
        GameObject enemy = (GameObject)Instantiate(Resources.Load("Prefab/EnemyShooting"));
        return enemy.GetComponent<CreateEnemy>();
    }

}
