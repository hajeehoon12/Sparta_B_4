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

        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);

        //firstCard�� ����ٸ�, �� ������ �Ѱ��ְ�

        if (GameManager.instance.firstCard == null)
        {
            GameManager.instance.firstCard = this; // card Class�� ������ �Ѱ��ش�.
            
        }
        else //firstCard�� �����Ѵٸ�, secondCard�� �������� �Ѱ��ְ� ���Ѵ�.
        {
            GameManager.instance.secondCard = this;
            GameManager.instance.Matched();
        }
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
