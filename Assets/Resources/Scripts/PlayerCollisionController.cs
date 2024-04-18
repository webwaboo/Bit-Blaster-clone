using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    GameObject player;
    PlayerHealth playerHealth;
    public CollectionController collectionController;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject;
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "InnerBorders")
        {
            print("destroy ship");
            playerHealth.DestroyShip();
        }
        else if(collision.gameObject.tag == "EnemyCollider")
        {
            playerHealth.TakeDamage();
            print("touch enemy");
        }else if(collision.gameObject.tag == "Collectable")
        {
            collectionController.Collect(collision.gameObject);
        }
    }
}
