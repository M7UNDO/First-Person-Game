using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using JetBrains.Annotations;

public class AudioManager : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider volumeSlider;
    public Slider volumeSlider2;
    public Slider volumeSlider3;
    // Start is called before the first frame update
    void Start()
    {
        //Master
        float currentVolume;
        masterMixer.GetFloat("MasterVolume", out currentVolume);
        volumeSlider.value = currentVolume; 

        volumeSlider.onValueChanged.AddListener(SetMasterVolume);

        //Music
        float currentMusicVolume;
        masterMixer.GetFloat("MusicVolume", out currentMusicVolume);
        volumeSlider2.value = currentMusicVolume;

        volumeSlider2.onValueChanged.AddListener(SetMusicVolume);

        //Sfx
        float currentSfxVolume;
        masterMixer.GetFloat("SfxVolume", out currentSfxVolume);
        volumeSlider3.value = currentSfxVolume;

        volumeSlider3.onValueChanged.AddListener(SetSfxVolume);
    }

    public void SetMasterVolume(float sliderValue)
    {
        masterMixer.SetFloat("MasterVolume", sliderValue);
    }

    public void SetMusicVolume(float sliderValue)
    {
        masterMixer.SetFloat("MusicVolume", sliderValue);
    }

    public void SetSfxVolume(float sliderValue)
    {
        masterMixer.SetFloat("SfxVolume", sliderValue);
    }

}
