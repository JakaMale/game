using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class starsHandler : MonoBehaviour
{

    public GameObject[] stars;
    
    private int score;
    public static int starsint = 0;
    [SerializeField] private Text starsNumber;


    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectsWithTag("coin").Length*100;

    }

    public void starshow()
    {
        int coinshave = PlayerController2D.coins;

        float procent = float.Parse(coinshave.ToString()) / float.Parse(score.ToString()) * 100;
     

          if (procent == 0)
        {
            stars[0].SetActive(true);
        }
        else if (procent > 0 && procent<=33)
        {
            stars[1].SetActive(true);
            starsint += 1;
            starsNumber.text = starsint.ToString();
        }
        else if (procent > 33 && procent <= 66)
        {
            stars[1].SetActive(true);
            stars[2].SetActive(true);
            starsint += 2;
            starsNumber.text = starsint.ToString();
        }
        else
        {
            stars[1].SetActive(true);
            stars[2].SetActive(true);
            stars[3].SetActive(true);
            starsint += 3;
            starsNumber.text = starsint.ToString();
        }
        
    }


}

