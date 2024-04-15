using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{

    public GameObject card;
    public float cardDist;
    public int cardNum = 16;
    public int length;

    // Start is called before the first frame update
    void Start()
    {

        int[] arr = {0,0,1,1,2,2,3,3,4,4,5,5,6,6,7,7};
        arr = arr.OrderBy(x => Random.Range(0f, 7f)).ToArray();



        length = (int)Mathf.Sqrt(cardNum);
        cardDist = 5.8f / length;

        for (int i = 0; i < cardNum; i++)
        {
            GameObject go = Instantiate(card, this.transform); // ,board 밑에 생성

            float x = (i % length) * cardDist - cardDist * length / 2 + 0.5f * cardDist ;
            float y = (i / length) * cardDist - cardDist * length / 2 ;
            
            
            go.transform.position = new Vector2(x, y);
            
            go.GetComponent<Card>().Setting(arr[i]); // Board의 하위에 있는 Card Script의 Component를 가져와서 Setting 함수를 arr[i]라는 매개변수를 통해 실행
            go.transform.localScale = new Vector2(cardDist - 0.1f, cardDist - 0.1f);

        }

        GameManager.instance.cardCount = arr.Length;


    }

    
}
