using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textchane : MonoBehaviour
{

    int stars = starsHandler.starsint;
    // Start is called before the first frame update
    void Start()
    {
        Text mytext = GameObject.Find("Canvas/starnum").GetComponent<Text>();
        mytext.text= stars.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
