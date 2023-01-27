using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int nc = 0;
    public LevelManager levelManager;
    public HealthBar healthBar;
    public int maxHealth = 10;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (currentHealth==0)
        {
            PlayerController2D.coins *= nc;
            levelManager.RespawnPlayer();
            for (int i = 0; i < 5; i++)
            {
                if (maxHealth > currentHealth)
                {

                    AddHealth(2);
                }
            }
        }
      


        if (Input.GetKeyDown(KeyCode.N))
        {
            if (currentHealth<10)
            {
                AddHealth(2);
            }
            
        }
    }
    void TakeDamage(int damage)
    {
        SoundManagerScript.PlaySound("hurt");
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    void AddHealth(int med)
    {
        currentHealth += med;
        healthBar.SetHealth(currentHealth);
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "medKit")
        {   
            Destroy(collision.gameObject);
            if (currentHealth<10)
            {
                AddHealth(2);
            }
            
            SoundManagerScript.PlaySound("medKit");
        }
        if(collision.tag == "falldie")
        {
            for (int i = 0; i < 5; i++)
            {
                if (maxHealth > currentHealth)
                {
                   
                    AddHealth(2);
                }
            }
           
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="enemy")
        {
            if (currentHealth == 0)
            {
                levelManager.RespawnPlayer();
                for (int i = 0; i < 5; i++)
                {
                    if (maxHealth > currentHealth)
                    {

                        AddHealth(2);
                        
                    }
                }
            }
            else  TakeDamage(2);
            
        }
    }

}
