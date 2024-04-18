using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager instance;
    public float highScore;
    public Text highScoreTxt;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }



    

    public void Record_High_Score(float totalScore)
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetFloat("highScore");

        
        }
        
    }

    private void Update()
    {
        highScoreTxt.text = highScore.ToString("N2");
    }


}
