using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    public float movSpeed; 
    float speedX, speedY;
    Rigidbody2D rb;
    private Animator anim;

    private bool faceLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") > 0 && faceLeft)
        {
            Flip();
            faceLeft = false;
            anim.SetBool("isWalking", true);
        }
        if(Input.GetAxis("Horizontal") < 0 && !faceLeft)
        {
            Flip();
            faceLeft = true;
            anim.SetBool("isWalking", true);
        }
        else 
        {
            anim.SetBool("isWalking", false);
        }

        if(Input.GetMouseButton(0))
        {
            anim.SetTrigger("isAttacking");
        }

        speedX = Input.GetAxis("Horizontal") * movSpeed;
        speedY = Input.GetAxis("Vertical") * movSpeed;
        rb.velocity = new Vector2(speedX, speedY);
    }

    private void Flip()
    { 
        var theScale = transform.localScale;
        theScale .x *= -1;
        transform.localScale = theScale;
    }
}
