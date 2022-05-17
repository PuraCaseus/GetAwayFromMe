using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotThrow : MonoBehaviour {

    public LayerMask enemyLayers;
    public Transform kickPoint;
    public float kickRate = 2f;
    float nextKickTime = 0f;

    public LucidBar lucidbar;
    public GameObject kruka;

    //[SerializeField] private AudioSource BigSwing;
    //[SerializeField] private AudioSource ManHurt;

    void Start(){
        //anim = GetComponent<Animator>();
    }
    
    void Update(){

        if(Time.time >= nextKickTime)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                
                Attack();
                nextKickTime = Time.time + 1f / kickRate;
                LucidBar.instance.UseLucid(1);
            }
        }  

    }

    void Attack(){

        if(lucidbar.GetComponent<LucidBar>().currentLucid>= 1)
        {
            Instantiate(kruka, transform.position, Quaternion.identity);
        }

    }


}
