using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

   Rigidbody2D rb;
    public float moveSpeed;
    public bool moveRight=false;
    SpriteRenderer spriteRenderer;

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hittingWall;

    private bool edge;
    public Transform edgeCheck;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()  
    {
        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
        edge= Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);
        if (hittingWall || !edge)
        {
            moveRight = !moveRight;
        }
        if (moveRight==true)
        {
            transform.localRotation=Quaternion.Euler(0f, 180, 0);
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else if(!moveRight)
        {
            transform.localRotation = Quaternion.Euler(0f, 0, 0);
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        
    }
}
