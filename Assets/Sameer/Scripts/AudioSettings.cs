using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{

    public AudioMixer AudioMixer;
    
    public void SetVolume (float volume)
    {
        volume = gameObject.GetComponent<Slider>().value;
        AudioMixer.SetFloat("Volume", volume);
    }
}
