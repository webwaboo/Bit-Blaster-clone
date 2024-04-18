using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public float duration;
    float killTime;
    public float blinkingTime;
    bool isBlinking = false;

    public string collectableType;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        killTime = Time.time + duration;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
     if((Time.time > killTime - blinkingTime) && !isBlinking) 
        {
            StartCoroutine(Blink());
            isBlinking = true;
        }
     if(Time.time > killTime)
        {
            Destroy(gameObject);
        }
    }

    //setup blinking for sprite
    IEnumerator Blink()
    {
        for (int i = 0; i<4; i++)
        {
            spriteRenderer.enabled = false;
            yield return new WaitForSeconds(0.25f);
            spriteRenderer.enabled = true;
            yield return new WaitForSeconds(0.25f);
        }
    }

    //create a ammo collectable
    public static Collectable CreateAmmo()
    {
        GameObject ammo = (GameObject)Instantiate(Resources.Load("Prefab/Ammo"));
        return ammo.GetComponent<Collectable>();
    }

    public static Collectable CreateLaser()
    {
        GameObject laser = (GameObject)Instantiate(Resources.Load("Prefab/Laser"));
        return laser.GetComponent<Collectable>();
    }

    public static Collectable CreateBerserk()
    {
        GameObject berserk = (GameObject)Instantiate(Resources.Load("Prefab/Berserk"));
        return berserk.GetComponent<Collectable>();
    }

    public static Collectable CreateMultiShot()
    {
        GameObject multishot = (GameObject)Instantiate(Resources.Load("Prefab/MultiShot"));
        return multishot.GetComponent<Collectable>();
    }

    public static Collectable CreateShield()
    {
        GameObject shield = (GameObject)Instantiate(Resources.Load("Prefab/Shield"));
        return shield.GetComponent<Collectable>();
    }

    public static Collectable CreateBomb()
    {
        GameObject bomb = (GameObject)Instantiate(Resources.Load("Prefab/Bomb"));
        return bomb.GetComponent<Collectable>();
    }
}
