using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    public float jumpingPower = 16f;
    private bool isFacingRight = true;


    public bool isDead = false;

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Transform groudCheck;
    [SerializeField]
    private LayerMask groudLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsCollidedDeadZone()) isDead = true;

        if (isDead)
        {
            //ignore
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if(Input.GetButtonDown("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        if (IsCollidedDeadZone()) isDead = true;
        if (isDead)
        {
            //ignore
            return;
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            isDead = true;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groudCheck.position, 0.2f, groudLayer);
    }

    private bool IsCollidedDeadZone()
    {
        var cameraPos = Camera.main.transform.position;
        var screenSizeY = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;
        return (transform.position.y + (transform.localScale.y / 2)) <= cameraPos.y - screenSizeY;
    }

    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
