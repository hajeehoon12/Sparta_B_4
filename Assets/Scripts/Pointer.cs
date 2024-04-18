
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{

    public GameObject holy;
    public GameObject love;
    public GameObject snow;

    public float effect = 0f;

    public int effnum;

    public static Pointer instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // game mouse pos = main camera world pos -make same fun
        this.transform.position = mousePos;
    }

    public void EffectOn()
    {
        effnum = Random.Range(1, 4);

        if (effnum == 1)
        {
            holy.SetActive(true);

        }
        else if (effnum == 2)
        {
            love.SetActive(true);

        }
        else
        {
            snow.SetActive(true);
        }
        Invoke("EffectOff", 0.2f);

    }

    private void EffectOff()
    {
        if (effnum == 1)
        {
            holy.SetActive(false);

        }
        else if (effnum == 2)
        {
            love.SetActive(false);

        }
        else
        {
            snow.SetActive(false);

        }

    }
}
