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

    public void IncreaseAmmo(int amount)
    {
        ammo += amount;
        ammoUI.text = "A" + ammo;
        SaveAmmo(ammo);
    }

    void SaveAmmo(int amount)
    {
        PlayerPrefs.SetInt("A",amount);
        PlayerPrefs.Save();

    }

    void ReadAmmo()
    {
        int ammo = PlayerPrefs.GetInt("A");
        ammoUI.text = "A" + ammo;
    }
    void OnApplicationQuit()
    {
        SaveAmmo(0);
    }

    public void UseAmmo(int amount)
    {
        ammo -= amount;
        ammoUI.text = "A" + ammo;
    }

}
