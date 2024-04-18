using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager instance;

    public float highScore = 0;

    public Text highScoreTxt;

    public string BestScore = "";

    public Text highScore_1;
    public Text highScore_2;
    public Text highScore_3;
    public Text highScore_4;

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
    }

    public void Record_High_Score(int num)
    {
        if (PlayerPrefs.HasKey(BestScore + num.ToString()))
        {
            float best = PlayerPrefs.GetFloat(BestScore+ num.ToString());

            if (best < GameManager.instance.totalScore)
            {
                PlayerPrefs.SetFloat(BestScore + num.ToString(), GameManager.instance.totalScore);
                GameManager.instance.BestTxt.text = GameManager.instance.totalScore.ToString("N1");
            }else
            {
                GameManager.instance.BestTxt.text = best.ToString("N1");
            }
        }else
        {
            PlayerPrefs.SetFloat(BestScore + num.ToString(), GameManager.instance.totalScore);
            GameManager.instance.BestTxt.text = GameManager.instance.totalScore.ToString("N1");
        }
    }

    private void Update()
    {
        for (int i = 1; i < 5; i++)
        {
            float stageScore=PlayerPrefs.GetFloat(BestScore + i.ToString());
            
            switch (i) // i = level
            {
                case 1:
                    if (highScore_1 != null) highScore_1.text = stageScore.ToString("N1");
                    break;
                case 2:
                    if (highScore_2 != null) highScore_2.text = stageScore.ToString("N1");
                    break;
                case 3:
                    if (highScore_3 != null) highScore_3.text = stageScore.ToString("N1");
                    break;
                case 4:
                    if (highScore_4 != null) highScore_4.text = stageScore.ToString("N1");
                    break;
            
            }

        }
    }


}
