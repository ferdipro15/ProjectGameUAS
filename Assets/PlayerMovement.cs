using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 7f;
    void Start()    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()   {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX*moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump")) {
            rb.velocity = new Vector2(rb.velocity.x,jumpForce);
        }

        UpdateAnimation();
    }

    private void UpdateAnimation() {
        if (dirX > 0f) {
            anim.SetBool("Running",true);
            sprite.flipX =false;
        }
        else if (dirX <0f) {
            anim.SetBool("Running",true);
            sprite.flipX =true;
        }
        else {
            anim.SetBool("Running",false);
        }
    }
}