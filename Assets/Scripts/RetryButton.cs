using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public static RetryButton instance;

    public static int Level;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Level1()
    {
        Level = 0;
        
    }
    public void Level2()
    {
        Level = 1;

    }
    
    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
        AudioManager.instance.audioSource.Play();
    }


}
