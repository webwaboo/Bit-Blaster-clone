using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingController : MonoBehaviour
{
    public float shootingSpeed;
    public float bulletSpeed;
    public int amountAmmo;

    public GameObject playerBulletPrefab;
    public GameObject bullets;
    public GameObject spawnPoint;
    public Text ammoText;

    float nextShot = 0;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > nextShot && amountAmmo>0) {
            Shoot();
        }
        
    }

    private void FixedUpdate()
    {
        ammoText.text = amountAmmo.ToString();
    }

    //shooting method
    void Shoot()
    {
        //will this as a ref to know if we can shoot another bullet
        nextShot = Time.time + shootingSpeed;

        //instantiate new bullet from bulletprefab
        GameObject newBullet = GameObject.Instantiate(playerBulletPrefab);
        //correlate spawnPoint to newBullet
        newBullet.transform.position = spawnPoint.transform.position;
        //put newBullet in bullet folder
        newBullet.transform.parent = bullets.transform;

        //get the rigidBody of the bullet
        Rigidbody2D newBulletRigidBody = newBullet.GetComponent<Rigidbody2D>();
        //add speed to the bullet
        newBulletRigidBody.AddForce(transform.up * bulletSpeed);
        //decrease ammo
        amountAmmo--;

    }
}
