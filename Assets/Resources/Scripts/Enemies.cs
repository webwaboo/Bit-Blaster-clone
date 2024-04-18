using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject[] spawnAeras;
    public int maxEnemiesAmountOnStart;
    public int extraEnemiesPerXTotalEnemies;
    public int currentEnemiesAmount = 0;
    public int totalEnemiesAmount =0;

    int maxEnemies;

    // Update is called once per frame
    void Update()
    {
        maxEnemies = maxEnemiesAmountOnStart + totalEnemiesAmount / extraEnemiesPerXTotalEnemies;
        if(currentEnemiesAmount < maxEnemies)
        {
            SpawnRandomEnemy();
        }
    }

    //actually spawn the enemy
    public void SpawnRandomEnemy() 
    {
        //create/instantiate enemy and setup
        CreateEnemy enemy;
        float v = Random.value;

        if(v >= 0.5f)
        {
            enemy = CreateEnemy.GetNewPrimitive();
        }else if(v >= 0.2f){
            enemy = CreateEnemy.GetNewSplitter();
        }
        else
        {
            enemy= CreateEnemy.GetNewShooting();
        }
        
        SetupNewEnemy(enemy);

        currentEnemiesAmount++;
        totalEnemiesAmount++;
    }

    //setup position and movement of spawned enemy
    public void SetupNewEnemy(CreateEnemy enemy, GameObject spawnArea=null) 
    { 
        //if spawn area is null, choose from the one we dragged
        if(spawnArea == null)
        {
            int i = Random.Range(0, spawnAeras.Length);
            spawnArea = spawnAeras[i];
        }

        //once spawn is defined, use GetSpawnedPosition to get a position
        Vector3 spawnPosition = GetSpawnPosition(spawnArea);

        //spawn enemy at the position
        enemy.transform.position = spawnPosition;
        //put new enemy to the enemy folder
        enemy.transform.parent = transform;

        //invoke enemymovementcontroller script
        EnemyMovementController enemyMovementController = enemy.movementController;

        //define movement of enemy according to spawn area
        if(spawnArea.name == "Left")
        {
            enemyMovementController.movementDirection = Vector3.right;
        }else if(spawnArea.name == "Right")
        {
            enemyMovementController.movementDirection = Vector3.left;
        }
        else if (spawnArea.name == "Top")
        {
            enemyMovementController.movementDirection = Vector3.down;
        }
        else if (spawnArea.name == "Bottom")
        {
            enemyMovementController.movementDirection = Vector3.up;
        }
    }

    //get spawn position
    Vector3 GetSpawnPosition(GameObject spawnArea)
    {
        Vector3 scale = spawnArea.transform.localScale;
        //define spawing area
        float x = spawnArea.transform.position.x + Random.Range(-scale.x/2, scale.x/2);
        float y = spawnArea.transform.position.y + Random.Range(-scale.y / 2, scale.y / 2);

        //calculate position
        Vector3 location = new Vector3(x, y,0);

        return location;
    }
}
