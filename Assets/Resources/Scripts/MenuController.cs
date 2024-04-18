using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Text highscoreText;
    public int highscoreInt;

    void Awake()
    {
        if (PlayerPrefs.HasKey("highscore"))
        {
            highscoreInt = PlayerPrefs.GetInt("highscore");
        }
        else
        {
            highscoreInt = 0;
            PlayerPrefs.SetInt("highscore", 0);
        }

        highscoreText.text = "Highscore: " + highscoreInt.ToString();
    }

    public void OnPlayClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void QuitAppplication()
    {
        Application.Quit();
    }
}
