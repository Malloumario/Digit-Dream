using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator anim;
    public Transform tr;
    public bool Grounded;
    public bool rotated = false;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        tr = GetComponent<Transform>();
        
     }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            rb.velocity = new Vector2(0, 2);
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetInteger("AnimState", 1);
        }
       
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            rb.velocity = new Vector2(0, -2);
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);
            anim.SetInteger("AnimState", 1);
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rb.velocity = new Vector2(2, 0);
            sr.flipY = false;
            tr.rotation = Quaternion.Euler(0, 0, -90);
            anim.SetInteger("AnimState", 1);
      
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-2, 0);
            sr.flipY = false;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            anim.SetInteger("AnimState", 1);
            rotated = false;
        }


        else
        {
            rb.velocity = new Vector2(0, 0);
            anim.SetInteger("AnimState", 0);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Grounded = true;
            Debug.Log("player stay");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Grounded = false;
            Debug.Log("player fly");
        }
    }
}
