using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int amountShields;
    public GameObject shipSprite;
    public float invincibleTime=2;
    public GameObject[] shieldSprites;
    public Score score;

    bool invincible=false;

    //take damage, blink or die
    public void TakeDamage()
    {
        if (!invincible)
        {
            amountShields--;
            if(amountShields < 0)
            {
                DestroyShip();
                Debug.Log("u dead");
            }
            else
            {
                StartCoroutine(InvincibleAfterDamage());
                Debug.Log("untouchable");
            }
        }
    }

    public void DestroyShip()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        PlayerPrefs.SetInt("highscore", score.currentScore);
        Destroy(gameObject);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    //temporary invincibility
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("triggered in player health");
    }
    public IEnumerator InvincibleAfterDamage()
    {
        //start invincibility
        invincible = true;
        Debug.Log("Chris Toucher");
        float invisTime = invincibleTime / 8;
        //blinking effect
        for(int i = 0;i < 4; i++)
        {
            shipSprite.SetActive(false);
            yield return new WaitForSeconds(invisTime);
            shipSprite.SetActive(true);
            yield return new WaitForSeconds(invisTime);
        }
        //not invincible anymore
        invincible = false;
        Debug.Log("Jacky Hands");
    }

    //decreases shield sprite depending on shield
    private void FixedUpdate()
    {
        for (int i = 0; i < shieldSprites.Length; i++)
        {
            if (i < amountShields)
            {
                shieldSprites[i].SetActive(true);
            }
            else
            {
                shieldSprites[i].SetActive(false);
            }
        }
    }
}
