using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    

    public Card firstCard;
    public Card secondCard;

    public Text successTxt;
    public Text BestTxt;

    public Text timeTxt;
    public GameObject endTxt;
    public GameObject success;
    public Text tryTxt;
    public Text totalTxt;

    

    
    

    AudioSource audioSource;
    public AudioClip clip; // match
    public AudioClip clip2; // when time is left half
    public AudioClip clip3; // when match success
    public AudioClip clip4; // when match failed

    public bool musicStart = true;
    public bool defeated = false;
   // bool waiting = false;


    public float totalScore = 0f;
    float waitTime = 0f;
    
    public string BastScore = "";


    public int cardCount = 0;
    public int cardMax;
    public int tryCount = 0;




    float time = 30f;
    public float maxtime = 30f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        SetLv();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        endTxt.gameObject.SetActive(false);
        musicStart = true;
        defeated = false;
        Time.timeScale = 1f;
        audioSource = GetComponent<AudioSource>();

        
    }
    
    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        waitTime += Time.deltaTime;
        timeTxt.text = time.ToString("N2");


        if (time < 0.0f)
        {
            if (!defeated)
            {
                audioSource.PlayOneShot(clip3);
            }
            defeated = true;
            End();
        }
        if (time < maxtime/2 && musicStart)
        {
            audioSource.PlayOneShot(clip2);
            musicStart = false;
            AudioManager.instance.StopSound();
            this.timeTxt.color = Color.red;
        }


    }


    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            //Debug.Log(firstCard.idx); // Goal 1. When Match, call teammate name


            audioSource.PlayOneShot(clip);

            firstCard.DestroyCard();
            secondCard.DestroyCard();

            cardCount -= 2;
            tryCount += 2;

            if (cardCount <= 0)
            {
                Invoke("End", 0.5f);
            }

            Success();

            
        }
        else
        {
            
            //Debug.Log("Fail"); // Goal1. When dismatch call fail
            firstCard.CloseCard();
            secondCard.CloseCard();
            firstCard.ChangeColor();
            secondCard.ChangeColor();
            tryCount += 2;
            Fail();
        }

        firstCard.waiting = false;
        firstCard = null;
        secondCard = null;
        Invoke("Off", 0.4f);

    }

    void End()
    {
        Time.timeScale = 0f;
        endTxt.gameObject.SetActive(true);
        tryTxt.text = tryCount.ToString();
        totalScore = time - tryCount/10 + cardMax;
        totalTxt.text = totalScore.ToString("N2");
        HighScoreManager.instance.Record_High_Score(Board.Instance.cardNum);
        if (time < 0)
        {
            time = 0;
        }

    }

    void Fail()
    {
        DisMatch.instance.Bbik();
        successTxt.text = "fail -time";
        success.gameObject.SetActive(true);
        time -= 0.3f; // additional timeless when fail match

    }
    void Success()
    {
        successTxt.text = Board.Instance.sprite[firstCard.idx].name.ToString();
        success.gameObject.SetActive(true);
        time += 2f; // add time when match
    }
    void Off()
    {
        success.gameObject.SetActive(false);
    }
    public void Wait5Sec()
    {
        firstCard.CloseCard();
        firstCard = null;

    }

    public void SetLv()
    {
        
        Board.Instance.cardNum = 16; 
        maxtime = 30f; //default
        Board.Instance.cardNum = ConnectMgr.instance.cardNum;
        time = ConnectMgr.instance.maxtime;
        maxtime = ConnectMgr.instance.maxtime;
        Board.Instance.iLv = ConnectMgr.instance.iLv;
    }


}
