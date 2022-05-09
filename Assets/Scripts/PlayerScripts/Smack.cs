using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smack : MonoBehaviour {

    public LayerMask enemyLayers;
    public Animator anim;
    public Transform kickPoint;

    public float kickRange = 0.5f;
    public int attackDamage = 10;

    public float kickRate = 2f;
    float nextKickTime = 0f;

    [SerializeField] private AudioSource LlamaKick;
    [SerializeField] private AudioSource ManHurt;

    void Start(){
        anim = GetComponent<Animator>();
    }
    
    void Update(){

        if(Time.time >= nextKickTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextKickTime = Time.time + 1f / kickRate;
            }
        }  

    }

    void Attack(){

        anim.SetTrigger("Whack");
        LlamaKick.Play();

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(kickPoint.position, kickRange, enemyLayers);
        
        foreach(Collider2D enemy in hitEnemies)
        {
            ///print("we hit" + enemy.name);
            enemy.GetComponent<Damageable>().TakeDamage(attackDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (kickPoint == null)
            return;
        Gizmos.DrawWireSphere(kickPoint.position, kickRange);
    }

}
