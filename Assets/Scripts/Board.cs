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

        //int[] arr = {0,0,1,1,2,2,3,3,4,4,5,5,6,6,7,7}; //���� �ڵ�
        int[] arr = new int[cardNum];
        for(int i = 0; i < arr.Length; ++i)
        {
            arr[i] = (i / 2);
        }

        arr = arr.OrderBy(x => Random.Range(0, cardNum + 1)).ToArray(); //Random.Range���� float���� �̻�,����. int���� �̻�,�̸��̾ 1�����ؼ� ������ �⵵����

        sprite = Resources.LoadAll<Sprite>("rtan");

        length = (int)Mathf.Sqrt(cardNum); //ī�尹���� ������. ī�� 16���̸� 4^2
        cardDist = 5.8f / length;       // ī����� ����. //5.8f�� ����ϴ� ȭ�� �� / ī�� ��

        for (int i = 0; i < cardNum; i++)
        {
            GameObject go = Instantiate(card, this.transform); // ,board �ؿ� ����

            float x = (i % length) * cardDist - cardDist * length / 2 + 0.5f * cardDist ; 
            float y = (i / length) * cardDist - cardDist * length / 2 ;
            
            
            go.transform.position = new Vector2(x, y);
            
            go.GetComponent<Card>().Setting(arr[i]); // Board�� ������ �ִ� Card Script�� Component�� �����ͼ� Setting �Լ��� arr[i]��� �Ű������� ���� ����
            go.transform.localScale = new Vector2(cardDist - 0.1f, cardDist - 0.1f); //�۵��ؿ�?

        }

        GameManager.instance.cardCount = arr.Length;
        GameManager.instance.cardMax = arr.Length;
    }

    // ���̵� ���ø��� 
    
}
