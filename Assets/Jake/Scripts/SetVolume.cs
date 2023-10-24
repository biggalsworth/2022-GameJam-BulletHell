using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    //This is a Public AudioMixer Function
    public AudioMixer mixer;

    //This is a Public Function called SetLevel which has a float in it called sliderValue which will be used to change the numbers using the Slider
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10 (sliderValue) * 20 ); //This makes it so the Volume can actually be changed by the number that the slider is set to
        Debug.Log("Volume Changed..."); //This will write "Volume Changed..." in the Console whenever the Slider is moved
    }
}
