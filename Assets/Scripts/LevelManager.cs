using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Transform respawnPoint;
    public GameObject playerPrefab;

    [Header("Currency)")]
    public static float currency = 0f;
    public Text currencyUI;

    
    void Awake()
    {
        instance = this;
    }
    
    public void Respawn()
    {
        GameObject player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
    }

    public void IncreaseCurrency(float amount)
    {
        currency += amount;
        currencyUI.text = "NF" + currency;
    }
}
