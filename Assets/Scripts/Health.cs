using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public GameObject gameOverScreen;
    // This is the image the of the healthbar that is showed to the player
    public Image healthBar;

    // The starting and max amount of health the player can have
    public float healthAmount = 100;

    public GameObject GameOverScreen;

    public GameObject effect;
    public Animator anim;

    [SerializeField] private AudioSource LlamanDeath;
    [SerializeField] private AudioSource LlamaHurt;

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
    }

    private void Update() // This checks if the health is at or below 0 and if so reload the scene
    {
        if(healthAmount <= 0)
        {

           
            // This stops the camera from trying to find the player which no longer exists, resulted in error wall.
            GameObject varGameObject = GameObject.Find("Main Camera");
            varGameObject.GetComponent<Camera_Follow>().enabled = false;

            Instantiate(effect, transform.position, Quaternion.identity);
            
            // This destroys the player object 
            Destroy(gameObject);
            

            //This enables the GameOver screen
           GameOver();
           
           //Application.LoadLevel(Application.loadedLevel);
        }
    }

    public void TakeDamage(float Damage) // This is the function we call from the enemy's script to deal damage to the player
    {
        healthAmount -= Damage;
        LlamaHurt.Play();
        healthBar.fillAmount = healthAmount / 100;
    }

    public void Healing(float healPoints) // This is the function we call from the enemy's script to heal the player
    {
        // This makes it so that healing wont "over-heal" the maximum amount (100)
        healthAmount += healPoints;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100;

    }
}
