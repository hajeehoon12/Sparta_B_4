using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public Card firstCard;
    public Card secondCard;

    public Text successTxt;

    public Text timeTxt;
    public GameObject endTxt;
    public GameObject success;
    public Text tryTxt;

    AudioSource audioSource;
    public AudioClip clip;
    public AudioClip clip2;

    public bool musicStart = true;

    



    public int cardCount = 0;
    public int tryCount = 0;


    float time = 30f;
    public float maxtime = 30f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        musicStart = true;
        Time.timeScale = 1f;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timeTxt.text = time.ToString("N2");


        if (time < 0.0f)
        {
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

        firstCard = null;
        secondCard = null;
        Invoke("Off", 0.4f);

    }

    void End()
    {
        Time.timeScale = 0f;
        endTxt.gameObject.SetActive(true);
        tryTxt.text = tryCount.ToString();
    }

    void Fail()
    {
        successTxt.text = "fail";
        success.gameObject.SetActive(true);

    }
    void Success()
    {
        successTxt.text = firstCard.idx.ToString();
        success.gameObject.SetActive(true);
    }
    void Off()
    {
        success.gameObject.SetActive(false);
    }


}
