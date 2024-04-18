using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    public GameObject StartBtn;
    public GameObject GridBtn;
    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
        AudioManager.instance.audioSource.Play();
    }

    public void SelectLV()
    {
        StartBtn.SetActive(false);
        GridBtn.SetActive(true);
    }

    public void StartLv1()
    {
        Lv1();
        Retry();
    }
    public void StartLv2()
    {
        Lv2();
        Retry();
    }
    public void StartLv3()
    {
        Lv3();
        Retry();
    }
    public void StartLv4()
    {
        Lv4();
        Retry();
    }

    public void Lv1()
    {
        //레벨 요소
        ConnectMgr.instance.cardNum = 16;
        ConnectMgr.instance.maxTime = 30f;
        
    }
    public void Lv2()
    {
        //레벨 요소
        ConnectMgr.instance.cardNum = 18;
        ConnectMgr.instance.maxTime = 30f;
        //보드 요소
        
    }
    public void Lv3()
    {
        //레벨 요소
        ConnectMgr.instance.cardNum = 20;
        ConnectMgr.instance.maxTime = 30f;
        //보드 요소
        
    }

    public void Lv4()
    {
        //레벨 요소
        ConnectMgr.instance.cardNum = 24;
        ConnectMgr.instance.maxTime = 30f;
        //보드 요소        
    }

}

