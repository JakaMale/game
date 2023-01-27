using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class settingsMenu : MonoBehaviour
{
   public static float volumer;
    public AudioMixer audioMixer;
  public void SetVolume(float volume)
    {
        volumer = volume;
        audioMixer.SetFloat("volume", volume);
    }
}
