using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameObject completelevelUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            completelevelUI.SetActive(true);
            GetComponent<starsHandler>().starshow();
        }
    }
}
