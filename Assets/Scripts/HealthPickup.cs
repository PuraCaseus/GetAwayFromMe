using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 public class HealthPickup : MonoBehaviour {

    GameObject Player; // finds the gameobject "Player"
    CapsuleCollider2D myCollider; // Uses the BoxCollider2D on the object
    public PlayerDamaged HealTarget; // a private 
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
            //anim.SetTrigger("Hurt");
            GameObject Player = collision.gameObject;
            HealTarget.Healing(healing); // Healing will heal 40 to the player
            Destroy(gameObject);
            Instantiate(effect, transform.position, Quaternion.identity);
            // A bunch of prints to make sure we see what works and what doesn't, was used in troubleshooting

            //print("playergamobject" + Player);

            //print("PlayerComponent.health" + Player.GetComponent<Health>());

            //print("collided with player");
            //print("playergamobject" + Player);
        }
    }
}