using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class masterVolume : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string soundpref = "soundpref";
    private int firstPlayInt;
    public Slider soundSlider;
    private float soundFloat;
    [Range(0.0f, 1.0f)]
    [SerializeField]
  public float masterVolumer = settingsMenu.volumer;

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if (firstPlayInt == 0)
        {
            soundFloat = .25f;
            soundSlider.value = soundFloat;
            PlayerPrefs.SetFloat(soundpref, soundFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);

        }
        else
        {
            soundFloat = PlayerPrefs.GetFloat(soundpref);
            soundSlider.value = soundFloat;

        }

    }
    
    public void Update()
    {
       
        AudioListener.volume = masterVolumer;
        soundSlider.value = masterVolumer;
        masterVolumer = soundSlider.value;
    }
    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(soundpref, soundSlider.value);

    }
    private void OnApplicationFocus(bool infocus)
    {
        if (!infocus)
        {
            SaveSoundSettings();
        }
    }
    public void UpdateSound()
    {
        masterVolumer = soundSlider.value;

    }
}
