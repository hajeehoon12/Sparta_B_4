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
    public int cardNum = 16;
    public int length;

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

        //int[] arr = {0,0,1,1,2,2,3,3,4,4,5,5,6,6,7,7}; //기존 코드
        int[] arr = new int[cardNum];
        for(int i = 0; i < arr.Length; ++i)
        {
            arr[i] = (i / 2);
        }

        arr = arr.OrderBy(x => Random.Range(0, cardNum + 1)).ToArray(); //Random.Range에서 float값은 이상,이하. int값은 이상,미만이어서 1을더해서 범위를 잡도록함

        sprite = Resources.LoadAll<Sprite>("rtan");

        length = (int)Mathf.Sqrt(cardNum); //카드갯수의 제곱근. 카드 16장이면 4^2
        cardDist = 5.8f / length;       // 카드사이 간격. //5.8f는 사용하는 화면 폭 / 카드 열

        for (int i = 0; i < cardNum; i++)
        {
            GameObject go = Instantiate(card, this.transform); // ,board 밑에 생성

            float x = (i % length) * cardDist - cardDist * length / 2 + 0.5f * cardDist ; 
            float y = (i / length) * cardDist - cardDist * length / 2 ;
            
            
            go.transform.position = new Vector2(x, y);
            
            go.GetComponent<Card>().Setting(arr[i]); // Board의 하위에 있는 Card Script의 Component를 가져와서 Setting 함수를 arr[i]라는 매개변수를 통해 실행
            go.transform.localScale = new Vector2(cardDist - 0.1f, cardDist - 0.1f); //작동해요?

        }

        GameManager.instance.cardCount = arr.Length;
        GameManager.instance.cardMax = arr.Length;
    }

    // 난이도 선택마다 
    
}
