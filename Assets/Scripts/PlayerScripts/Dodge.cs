using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : MonoBehaviour {

    public Animator anim;
    public float kickRate = 2f;
    float nextKickTime = 0f;
    public ManaBar manabar;

    void Start(){
        anim = GetComponent<Animator>();
    }
    
    void Update(){

        if(Time.time >= nextKickTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                Avoid();
                nextKickTime = Time.time + 1f / kickRate;
                ManaBar.instance.UseMana(30);
            }
        }  

    }

    void Avoid(){

        if(manabar.GetComponent<ManaBar>().currentMana>= 30)
        {
        anim.SetTrigger("Dodge");
    }

    }

}
