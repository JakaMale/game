using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    bool preveriBullet = PlayerController2D.preveri;
   
    
    private Rigidbody2D rb;
    
    
    // Update is called once per frame
    void FixedUpdate()
    {
        rb = GetComponent<Rigidbody2D>();    

        if (preveriBullet == false)
        {
            
            rb.velocity = new Vector2(10, 0);
        }
        else
        {
            
            GetComponent<SpriteRenderer>().flipX = true;
            rb.velocity = new Vector2(-10, 0);
        }
        Invoke("DestroyBullet", .5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            DestroyBullet();
          
        }
    }
    void DestroyBullet()
    {
        Destroy (gameObject);
    }
   
}
