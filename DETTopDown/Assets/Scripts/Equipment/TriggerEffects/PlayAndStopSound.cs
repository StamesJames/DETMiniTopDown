using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAndStopSound : PressAndReleasEffect
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    protected override void Releas()
    {
        audioSource.Stop();
    }

    protected override void Trigger()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
