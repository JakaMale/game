using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class PlayerController2D : MonoBehaviour
{
  
    AudioSource audioSrc;
    public static bool preveri =false;
    bool isMoving = false;
    Animator animator;
    Object bulletRef;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
   public bool isGrounded;
    float bulletXOffset = 1f;
    public bool isGroundedl;
    public bool isGroundedr;
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    Transform groundCheckl;
    [SerializeField]
    Transform groundCheckr;
    [SerializeField] public static int coins = 0;
    [SerializeField] private Text scoreNumber;
    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        bulletRef = Resources.Load("Bullet");
        audioSrc = GetComponent<AudioSource>();
       
    }


    private void Update()
    {

       
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("tiles")) ||
            Physics2D.Linecast(transform.position, groundCheckl.position, 1 << LayerMask.NameToLayer("tiles")) ||
            Physics2D.Linecast(transform.position, groundCheckr.position, 1 << LayerMask.NameToLayer("tiles")))
        {
            isGrounded = true;
            isGroundedl = true;
            isGroundedr = true;
        }
        else
        {
            isGrounded = false;
            isGroundedl = false;
            isGroundedr = false;
            animator.Play("jump");
        }

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            
            rb.velocity = new Vector2(5, rb.velocity.y);
            if (isGrounded) { 
                animator.Play("walk");
               
                isMoving = true;
            }
            spriteRenderer.flipX = false;
            if (spriteRenderer.flipX == true)
            {

                preveri = true;


            }
            else
            {
                preveri = false;

            }
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            
            rb.velocity = new Vector2(-5, rb.velocity.y);
           
            if (isGrounded)
            {
                animator.Play("walk");
                isMoving = true;
            }
               

            spriteRenderer.flipX = true;
            
            if (spriteRenderer.flipX == true)
            {

                preveri = true;
                

            }
            else
            {
                preveri = false;
                
            }

        }

        else
        {
            if (isGrounded)
               
                    animator.Play("idle");
                
                
            isMoving = false;
            
                rb.velocity = new Vector2(0, rb.velocity.y);
            
           
        }
        if (isMoving==true)
        {
            if (!audioSrc.isPlaying)
            {
                audioSrc.Play();
            }
             }
        else if (isGrounded==false)
        {
            audioSrc.Stop();
        }
        else if (isGroundedl == false)
        {
            audioSrc.Stop();
        }
        else if (isGroundedr == false)
        {
            audioSrc.Stop();
        }
        else 
        {
            audioSrc.Stop();
        }
        if (Input.GetKeyDown("w") && isGrounded)
        {
            SoundManagerScript.PlaySound("jump");
            rb.velocity = new Vector2(rb.velocity.x, 11.5f);

            if (isGrounded) {
                animator.Play("jump"); }
            isMoving = false;
        }
        scoreNumber.text = coins.ToString();

        if (Input.GetButtonDown("Fire1"))
        {   
            SoundManagerScript.PlaySound("punch");
            animator.Play("punch");
            GameObject bullet = (GameObject)Instantiate(bulletRef);
            isMoving =false;


            if (spriteRenderer.flipX == true)
            {
                
                
                bullet.transform.position = new Vector3(x: transform.position.x - bulletXOffset, y: transform.position.y + .2f, z: 1); 
              
            }
            else
            {
                
                bullet.transform.position = new Vector3(transform.position.x + bulletXOffset, transform.position.y + .2f, 1);
            }
            

        }
        if (Input.GetKey(KeyCode.Escape))
        {
            coins = 0;
        }
}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "coin")
        {
            Destroy(collision.gameObject);
            coins += 100;
            scoreNumber.text = coins.ToString();
            SoundManagerScript.PlaySound("coin");

        }
        if (collision.tag == "falldie")
        {
          coins = 0;
            scoreNumber.text = coins.ToString();
        }
       
    }
}
  
    



