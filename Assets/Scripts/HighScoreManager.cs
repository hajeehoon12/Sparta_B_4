using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager instance;

    public float highScore = 0;
    public Text highScoreTxt;

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
    }

    public void Record_High_Score(int num)
    {
        if (PlayerPrefs.HasKey(GameManager.instance.BastScore + num))
        {
            float best = PlayerPrefs.GetFloat(GameManager.instance.BastScore+num);

            if (best < GameManager.instance.totalScore)
            {
                PlayerPrefs.SetFloat(GameManager.instance.BastScore + num, GameManager.instance.totalScore);
                GameManager.instance.BestTxt.text = GameManager.instance.totalScore.ToString("N2");
            }else
            {
                GameManager.instance.BestTxt.text = best.ToString("N2");
            }
        }else
        {
            PlayerPrefs.SetFloat(GameManager.instance.BastScore + num, GameManager.instance.totalScore);
            GameManager.instance.BestTxt.text = GameManager.instance.totalScore.ToString("N2");
        }
    }

    private void Update()
    {

    }


}
