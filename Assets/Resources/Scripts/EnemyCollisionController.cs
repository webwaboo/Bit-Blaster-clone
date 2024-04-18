using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionController : MonoBehaviour
{
    Enemies enemiesScript;
    private void Awake()
    {
        GameObject gaOb = GameObject.FindGameObjectWithTag("EnemySpawnGameObject");
        enemiesScript = gaOb.GetComponent<Enemies>();
    }

    //destroy object et decrease enemy amount if it touches the wall
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "OuterBorders")
        {
            enemiesScript.currentEnemiesAmount--;
            Destroy(transform.parent.gameObject);
        }
    }
     
}
