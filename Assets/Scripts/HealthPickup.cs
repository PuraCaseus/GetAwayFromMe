using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 public class HealthPickup : MonoBehaviour {

    GameObject Player; // finds the gameobject "Player"
    CapsuleCollider2D myCollider; // Uses the BoxCollider2D on the object
    public PlayerDamaged HealTarget;
    public GameObject effect;

    public float healing;

    //public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<CapsuleCollider2D>();
        GameObject ThePlayer = GameObject.Find("ThePlayer");
        HealTarget = ThePlayer.gameObject.GetComponent<PlayerDamaged>();
    }
    public void OnTriggerEnter2D(Collider2D collision) // Checks if a collision occurs
    {

        if (collision.gameObject.tag == "Player") // makes the colliding game object call the function "TakeDamage" from the "Health" script
        {
            GameObject Player = collision.gameObject;
            HealTarget.Healing(healing);
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
        }
    }
}