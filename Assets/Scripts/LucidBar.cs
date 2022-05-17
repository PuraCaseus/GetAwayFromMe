using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LucidBar : MonoBehaviour
{
    public Slider lucidBar;

    public int maxLudic = 300;
    public int currentLucid;

    public WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    public Coroutine regen;

    public static LucidBar instance;

    public Vector3 Offset;

    private void Awake()
    {
        instance = this;
    }

        void Update()
    {
        lucidBar.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentLucid = maxLudic;
        lucidBar.maxValue = maxLudic;
        lucidBar.value = maxLudic;
    }

    public void UseLucid(int amount)
    {
        if (currentLucid - amount >= 0)
        {
            currentLucid -= amount;
            lucidBar.value = currentLucid;

            if (regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenLucid());
        }
        else
        {
            Debug.Log("Not Enough Lucid!");
        }
    }

    private IEnumerator RegenLucid()
    {
        yield return new WaitForSeconds(1);

        while(currentLucid < maxLudic)
        {
            currentLucid += maxLudic / 100;
            lucidBar.value = currentLucid;
            yield return regenTick;
        }
    }
}