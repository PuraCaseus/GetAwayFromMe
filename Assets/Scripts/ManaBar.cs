using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider manaBar;

    public int maxMana = 300;
    public int currentMana;

    public WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    public Coroutine regen;

    public static ManaBar instance;

    public Vector3 Offset;

    private void Awake()
    {
        instance = this;
    }

        void Update()
    {
        manaBar.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentMana = maxMana;
        manaBar.maxValue = maxMana;
        manaBar.value = maxMana;
    }

    public void UseMana(int amount)
    {
        if (currentMana - amount >= 0)
        {
            currentMana -= amount;
            manaBar.value = currentMana;

            if (regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenMana());
        }
        else
        {
            Debug.Log("Not Enough Mana!");
        }
    }

    private IEnumerator RegenMana()
    {
        yield return new WaitForSeconds(1);

        while(currentMana < maxMana)
        {
            currentMana += maxMana / 50;
            manaBar.value = currentMana;
            yield return regenTick;
        }
    }
}