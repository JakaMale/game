using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip bullSound, jumpSound, coinSound, healSound, hurtSound;
    static AudioSource audioSrc;
    

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        bullSound = Resources.Load<AudioClip>("bullSound");
        jumpSound = Resources.Load<AudioClip>("jumpSound");
        coinSound=Resources.Load<AudioClip>("coinSound");
        healSound = Resources.Load<AudioClip>("healSound");
        hurtSound = Resources.Load<AudioClip>("hurtSound");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound (string clip)
    {
        switch (clip)
        {
           
            case "punch":
                audioSrc.PlayOneShot(bullSound);
                break;
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "coin":
                audioSrc.PlayOneShot(coinSound);
                break;
            case "medKit":
                audioSrc.PlayOneShot(healSound);
                break;
            case "hurt":
                audioSrc.PlayOneShot(hurtSound);
                break;
        }
      
      
    }
}
