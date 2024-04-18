using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyController : MonoBehaviour
{
    public int pointsOnPlayerDestruction;
    public bool isSplitter = false;

    Score score;
    Enemies enemiesScript;
    Collectables collectables;

    private void Awake()
    {
        GameObject gaOb = GameObject.FindGameObjectWithTag("EnemySpawnGameObject");
        enemiesScript = gaOb.GetComponent<Enemies>();

        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();

        collectables = GameObject.FindGameObjectWithTag("Collectables").GetComponent<Collectables>();
    }

    //defines what happens when enemy is destroyed by player
    public void DestroyedByPlayer()
    {
        Debug.Log("Destroyed by the player");
        score.RaiseScore(pointsOnPlayerDestruction);
        collectables.SpawnRandomCollectable(transform);
        enemiesScript.currentEnemiesAmount--;
        Destroy(gameObject);
    }
}
