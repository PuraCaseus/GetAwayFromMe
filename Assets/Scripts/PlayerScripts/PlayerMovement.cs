using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;

    public Animator anim;


    void Start()
    {
        
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

              if (movement.x == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else {
            anim.SetBool("isRunning", true);
     
        }

        movement.y = Input.GetAxisRaw("Vertical");
                     if (movement.y == 0)
        {
            anim.SetBool("isRunningY", false);
        }
        else {
            anim.SetBool("isRunningY", true);
     
        }



    }


    void FixedUpdate()
    {

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (movement.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (movement.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }


    }
