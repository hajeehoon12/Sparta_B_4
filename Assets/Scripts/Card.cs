using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int idx = 0;

    public GameObject front;
    public GameObject back;

    Color color;

    public Animator anim;
    public bool waiting = false;

    AudioSource audioSource;
    public AudioClip clip;

    public SpriteRenderer frontImage;
    public SpriteRenderer backImage;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setting(int number)
    {
        idx = number;
        frontImage.sprite = Board.Instance.sprite[idx];
    }

    public void OpenCard()
    {
        if (GameManager.instance.secondCard != null) return;

        audioSource.PlayOneShot(clip);

        Pointer.instance.EffectOn(); // pointer effect activate

        //firstCard가 비었다면, 내 정보를 넘겨주고

        if (GameManager.instance.firstCard == null)
        {
            GameManager.instance.firstCard = this; // card Class의 정보를 넘겨준다.
            
        }
        else //firstCard가 존재한다면, secondCard에 내정보를 넘겨주고 비교한다.
        {
            GameManager.instance.secondCard = this;
            GameManager.instance.Matched();
        }
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);
    }



    
    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 0.45f);
    }

    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }
    




    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.45f);
    }
    void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }

    public void ChangeColor()
    {
        ColorUtility.TryParseHtmlString("#00ffff", out color);

        backImage.color = color;
    }
    
   
}
