using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{

   [SerializeField]private int neki = 50;
   // public int hp = 5;
    public int health = 5;
    private Material matWhite;
    private Material matDefault;
    private UnityEngine.Object explosionRef;
    private UnityEngine.Object enemyRef;
    SpriteRenderer sr;  
    // Start is called before the first frame update
    void Start()
    {
        enemyRef = Resources.Load("duh");
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("Whiteflash", typeof(Material)) as Material;
        matDefault= sr.material;
        explosionRef = Resources.Load("explosion");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ground"))
        {
            sr.material = matWhite;
            Destroy(collision.gameObject);
            health--;
            if(health<=0)
            {
                killself();

                

            }
            else
            {
                
                Invoke("ResetMaterial", .1f);
            }
        }
    }
    private void ResetMaterial()
    {
        sr.material = matDefault;
    }
    private void killself()
    {
        GameObject explosion = (GameObject)Instantiate(explosionRef);
        explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //Destroy(gameObject);
        gameObject.SetActive(false);
       
        PlayerController2D.coins += neki;

    }
    void Respawn()
    {
        GameObject enemyClone = (GameObject)Instantiate(enemyRef);
        enemyClone.transform.position = transform.position;
        //health = ;
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
