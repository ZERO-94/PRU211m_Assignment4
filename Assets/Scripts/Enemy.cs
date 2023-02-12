using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

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
        //no moving if not in ground
        if (!IsGrounded())
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
            return;
        }

        if (IsFacingRight())
        {
            rb.velocity = new Vector2(speed, 0f);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0f);
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groudCheck.position, 0.2f, groudLayer);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        transform.localScale = new Vector2( -Mathf.Sign(rb.velocity.x), transform.localScale.y);
    }
}
