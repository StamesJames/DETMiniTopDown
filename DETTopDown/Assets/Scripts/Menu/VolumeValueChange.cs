using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeValueChange : MonoBehaviour
{

    [SerializeField] AudioMixer audioMixer;

    [SerializeField] Slider slider;

    [SerializeField] string groupName;

    private float Float;

    public void audioFunction()
    {
        audioMixer.SetFloat(groupName,slider.value);
    }
    private void OnEnable()
    {
        //läd gespeicherte Volume einstellung
        audioMixer.GetFloat(groupName,out Float);
        slider.value = Float;
    }
}