using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectMgr : MonoBehaviour
{
    public static ConnectMgr instance;

    public int cardNum = 0;
    public float maxTime;

    //public int irowNum;
    //public float fCard_size;
    //public float fSpacing;
    //public float fXPosCorrection;
    //public float fYPosCorrection;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
