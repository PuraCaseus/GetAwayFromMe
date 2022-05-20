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
    public static int currency = 0;
    public Text currencyUI;

    
    void Awake()
    {
        instance = this;
        ReadCurrency();
    }
    
    public void Respawn()
    {
        GameObject player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
        currencyUI.text = "x" + currency;
        SaveCurrency(currency);
    }

    void SaveCurrency(int amount)
    {
        PlayerPrefs.SetInt("x",amount);
        PlayerPrefs.Save();

    }

    void ReadCurrency()
    {
        int currency = PlayerPrefs.GetInt("x");
        currencyUI.text = "x" + currency;
    }
    void OnApplicationQuit()
    {
        SaveCurrency(0);
    }
}
