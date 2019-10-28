using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAndStopSound : PressAndReleasEffect
{
    [SerializeField] AudioSource[] audioSources;

    protected override void Releas()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.Stop();
        }
    }

    protected override void Trigger()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.Play();
        }
    }
}
