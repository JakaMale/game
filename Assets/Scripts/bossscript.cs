using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossscript : MonoBehaviour
{
    private int health = 10;
    private Material matWhite;
    private Material matDefault;
    private UnityEngine.Object explosionRef;
    
    SpriteRenderer sr;
    public GameObject bossPrefab;
    public float minSize;
    GameObject clone;
    GameObject clone1;
    // Start is called before the first frame update
    void Start()
    {
        
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("Whiteflash", typeof(Material)) as Material;
        matDefault = sr.material;
        explosionRef = Resources.Load("explosion");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            sr.material = matWhite;
            Destroy(collision.gameObject);
            health--;
            if (health <= 0)
            {
                killself(); if (transform.localScale.y > minSize)
                {
                    ResetMaterial();

                    clone = Instantiate(bossPrefab, new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
                    health = 10;
                    clone1 = Instantiate(bossPrefab, new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z), Quaternion.identity) as GameObject;
                    health = 10;


                }
                
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
        Destroy(gameObject);
    }
   
    // Update is called once per frame
    void Update()
    {

    }
}
