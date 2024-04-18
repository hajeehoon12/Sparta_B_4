using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait5 : MonoBehaviour
{
    private IEnumerator m_Coroutine;

    void Start()
    {
        m_Coroutine = CoroutineMethod();
        StartCoroutine(m_Coroutine); // �ڷ�ƾ�� �����ϴ� �Լ�
    }

    IEnumerator CoroutineMethod() // ��
    {
        
        yield return new WaitForSeconds(5f); // ��
        GameManager.instance.Wait5Sec();
        
    }

}
