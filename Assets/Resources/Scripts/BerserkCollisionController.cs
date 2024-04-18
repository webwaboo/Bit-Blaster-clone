using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerserkCollisionController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyCollider")
        {
            EnemyDestroyController edc = collision.transform.parent.GetComponent<EnemyDestroyController>();
            edc.DestroyedByPlayer();
        }
    }
}
