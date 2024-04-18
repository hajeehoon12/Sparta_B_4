using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.U2D;

public class Board : MonoBehaviour
{
    public static Board Instance;

    public Sprite[] sprite;

    public GameObject card;
    public float cardDist;
    public int cardNum;
    public int length;
    public int level = RetryButton.Level;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {


        if (level == 0)
        {
            cardNum = 16;
        }else if (level == 1)
        {
            cardNum = 20;
        }

        int[] cardArr = new int[cardNum];
        for (int i = 0; i < cardNum/2; i++)
        {
            cardArr[i+i] = i;
            cardArr[i+i+1] = i;
        }

        
        sprite = Resources.LoadAll<Sprite>("rtan");
        cardArr = cardArr.OrderBy(x => Random.Range(0f, cardNum / 2f)).ToArray();

        length = (int)Mathf.Sqrt(cardNum);
        cardDist = 5.8f / length;

            for (int i = 0; i < cardNum; i++)
            {
                
                GameObject go = Instantiate(card, this.transform); // ,board 밑에 생성


                float x = (i % length) * cardDist - cardDist * length / 2 + 0.5f * cardDist;
                float cardY = 0.0f;
                if (level == 0)
                {
                    cardY = (i / length) * cardDist - cardDist * length / 2;
                    
                }
                else if (level == 1)
                {
                    cardY = (i / length) * cardDist - cardDist * length / 2 * 1.3f;
                    
                }


                go.transform.position = new Vector2(x, cardY);

                go.GetComponent<Card>().Setting(cardArr[i]); // Board의 하위에 있는 Card Script의 Component를 가져와서 Setting 함수를 arr[i]라는 매개변수를 통해 실행
                go.transform.localScale = new Vector2(cardDist - 0.1f, cardDist - 0.1f);

            }
        

        GameManager.instance.cardCount = cardArr.Length;
        GameManager.instance.cardMax = cardArr.Length;


    }

    
}
