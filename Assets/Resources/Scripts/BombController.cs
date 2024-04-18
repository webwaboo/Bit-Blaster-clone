using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    public int amountBombs;
    public GameObject[] bombSprites;
    public GameObject enemiesGaOb;
    public GameObject bulletGaOb;
    
    // Start is called before the first frame update
    void Start()
    {
        //number of bombs player starts with
        int startingNukeAmount = 5;
        amountBombs = startingNukeAmount;
    }

    // Update is called once per frame
    void Update()
    {
        //input for bombs
        if(Input.GetKeyDown(KeyCode.B))
        {
            print("bombing");
            IgniteNuke();
        }
    }

    //actual bombing
    void IgniteNuke()
    {
        if(amountBombs>0)
        {
            //call enemydestroy method for each each enemy destroyed
            foreach(Transform enemy in enemiesGaOb.transform)
            {
                EnemyDestroyController enemyDestroyController = enemy.GetComponent<EnemyDestroyController>();
                enemyDestroyController.DestroyedByPlayer();
            }
            //destroy all bullets
            foreach(Transform enemyBullet in bulletGaOb.transform)
            {
                Destroy(enemyBullet.gameObject);
            }
            //decreaase bomb
            amountBombs--;

        }

    }

    //decreases sprite depending on bombs
    private void FixedUpdate()
    {
        for(int i = 0; i < bombSprites.Length; i++)
        {
            if(i<amountBombs)
            {
                bombSprites[i].SetActive(true);
            }
            else
            {
                bombSprites[i].SetActive(false);
            }
        }
    }
}
