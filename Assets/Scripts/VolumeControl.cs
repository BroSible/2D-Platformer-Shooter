using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource[] audioSources;

    public void Start()
    {
        volumeSlider.value = AudioListener.volume;
        volumeSlider.onValueChanged.AddListener(delegate { OnVolumeChanged(); });
    }
    void OnVolumeChanged()
    {
        AudioListener.volume = volumeSlider.value;

        foreach (var audioSource in audioSources)
        {
            if (audioSource != null)
            {
                audioSource.volume = volumeSlider.value;
            }
        }
    }

}
