using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShot : MonoBehaviour
{
    float nextShot = 0f;
    public float shootingSpeed;
    public float bulletSpeed;

    public GameObject playerBulletPrefab;
    public GameObject bullets;
    public GameObject [] multiShotSpawnPoint;
    public void ShootRepeating()
    {
        //if the time is right...
        if(Time.time > nextShot + shootingSpeed)
        {
            //will this as a ref to know if we can shoot another bullet
            nextShot = Time.time + shootingSpeed;

            //will correlate bullets to each spawnpoint
            foreach (GameObject spawnPoint in multiShotSpawnPoint)
            {
                //instantiate new bullet from bulletprefab
                GameObject newBullet = GameObject.Instantiate(playerBulletPrefab);
                //correlate spawnPoint to newBullet
                newBullet.transform.position = spawnPoint.transform.position;
                //put newBullet in bullet folder
                newBullet.transform.parent = bullets.transform;

                //get the rigidBody of the bullet
                Rigidbody2D newBulletRigidBody = newBullet.GetComponent<Rigidbody2D>();
                //create custom direction for bullet based on player and spawnpoint position
                Vector3 dir = (spawnPoint.transform.position - gameObject.transform.position).normalized;
                //add speed and direction to the bullet
                newBulletRigidBody.AddForce(dir * bulletSpeed);
            }
        }
        
        
    }
}
