using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait5 : MonoBehaviour
{
    private IEnumerator m_Coroutine;

    

    void OnEnable()
    {
        m_Coroutine = CoroutineMethod();

        if (GameManager.instance.secondCard == null && GameManager.instance.firstCard != null)  //아무래도 firstCard에 정보가 담기는 것보다 이 함수가 더 빨리 실행되는것 같다.       
        {
            StartCoroutine(m_Coroutine); // 코루틴을 시작하는 함수
        }
    }

    IEnumerator CoroutineMethod() // ②
    {
        Debug.Log("Enter CoroutineMethod");
        yield return new WaitForSeconds(5f); // ③
        Debug.Log("after 5f");
        GameManager.instance.Wait5Sec();
        Debug.Log("after Wait5Sec()");

    }
}
