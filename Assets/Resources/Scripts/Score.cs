using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int currentScore;
    public Text scoreText;

    //increase according to points
    public void RaiseScore (int points)
    {
        currentScore += points;
    }

    //update the score
    private void FixedUpdate()
    {
        scoreText.text = currentScore.ToString();
    }
}
