using UnityEngine;
using UnityEngine.UI;
public class audioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string soundpref = "soundpref";
    private int firstPlayInt;
    public Slider soundSlider;
    private float soundFloat;
    

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if(firstPlayInt==0)
        {
            soundFloat = .25f;
            soundSlider.value = soundFloat;
            PlayerPrefs.SetFloat(soundpref, soundFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);

        }
        else
        {
           soundFloat= PlayerPrefs.GetFloat(soundpref);
            soundSlider.value = soundFloat;

        }
        
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
        AudioListener.volume = soundSlider.value;

    }


}
