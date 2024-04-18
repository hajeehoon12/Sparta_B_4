using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{

    public float highScore = 0;
    public Text highScoreTxt;

    void Record_High_Score(float totalScore)
    {
        if (totalScore > highScore)
        {
            highScore = totalScore;
        }
    }

    private void Update()
    {
        highScoreTxt.text = highScore.ToString("N2");
    }


}
