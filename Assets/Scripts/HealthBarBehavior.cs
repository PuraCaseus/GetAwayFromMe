using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarBehavior : MonoBehaviour
{
    public Slider HealthBar;
    public Color Low;
    public Color High;
    public Vector3 Offset;

    public void SetHealth(float health, float maxHealth)
    {
        HealthBar.gameObject.SetActive(health < maxHealth);
        HealthBar.value = health;
        HealthBar.maxValue = maxHealth;

        HealthBar.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, HealthBar.normalizedValue);
    }
    void Update()
    {
        HealthBar.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }
}
