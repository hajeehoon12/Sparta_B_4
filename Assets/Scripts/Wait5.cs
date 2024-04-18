using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait5 : MonoBehaviour
{
    private IEnumerator m_Coroutine;


    void Start()
    {
        m_Coroutine = CoroutineMethod();
        StartCoroutine(m_Coroutine); // 코루틴을 시작하는 함수
    }

    IEnumerator CoroutineMethod() // ②
    {
        
        yield return new WaitForSeconds(5f); // ③
        GameManager.instance.Wait5Sec();
        
    }

}
