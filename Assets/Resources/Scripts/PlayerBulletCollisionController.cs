using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCollisionController : MonoBehaviour
{
    //if bullet touches wall or enemy, get destroyed
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "InnerBorders")
        {
            Destroy(gameObject);
        }else if(collision.gameObject.tag == "EnemyCollider")
        {
            EnemyDestroyController enemyDestroyController = collision.transform.parent.GetComponent<EnemyDestroyController>();
            enemyDestroyController.DestroyedByPlayer();
            Destroy(gameObject);

        }

    }
}
