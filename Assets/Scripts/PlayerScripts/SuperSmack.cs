using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSmack : MonoBehaviour {

    public LayerMask enemyLayers;
    private Animator anim;
    public Transform kickPoint;

    public float kickRange = 0.5f;
    public int attackDamage = 10;

    public float kickRate = 2f;
    float nextKickTime = 0f;

    public ManaBar manabar;
    public GameObject SwingEffect;

    [SerializeField] private AudioSource BigSwing;
    [SerializeField] private AudioSource ManHurt;

    void Start(){
        anim = GetComponent<Animator>();
    }
    
    void Update(){

        if(Time.time >= nextKickTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                
                Attack();
                nextKickTime = Time.time + 1f / kickRate;
                ManaBar.instance.UseMana(70);
            }
        }  

    }

    void Attack(){

        if(manabar.GetComponent<ManaBar>().currentMana>= 70)
        {
        anim.SetTrigger("BigWhack");
        BigSwing.Play();
        Instantiate(SwingEffect, transform.position, Quaternion.identity);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(kickPoint.position, kickRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            ///print("we hit" + enemy.name);
            enemy.GetComponent<Damageable>().TakeDamage(attackDamage);
        }


        }

    }
    private void OnDrawGizmosSelected()
    {
        if (kickPoint == null)
            return;
        Gizmos.DrawWireSphere(kickPoint.position, kickRange);
    }

}
