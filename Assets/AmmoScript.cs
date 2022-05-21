using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoScript : MonoBehaviour
{
    public static AmmoScript instance;
    public GameObject playerPrefab;

    [Header("Ammo)")]
    public int ammo = 0;
    public Text ammoUI;
    
    void Awake()
    {
        instance = this;
        ReadAmmo();
    }

    public void IncreaseCurrency(int amount)
    {
        ammo += amount;
        ammoUI.text = "x" + ammo;
        SaveAmmo(ammo);
    }

    void SaveAmmo(int amount)
    {
        PlayerPrefs.SetInt("x",amount);
        PlayerPrefs.Save();

    }

    void ReadAmmo()
    {
        int ammo = PlayerPrefs.GetInt("x");
        ammoUI.text = "x" + ammo;
    }
    void OnApplicationQuit()
    {
        SaveAmmo(0);
    }

    public void UseAmmo(int amount)
    {
        ammo -= amount;
        ammoUI.text = "x" + ammo;
    }

}
