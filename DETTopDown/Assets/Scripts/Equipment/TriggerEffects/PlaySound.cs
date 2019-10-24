using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : TriggerEffect
{
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] AudioSource audioSource;
    [Header("Sound Pitch varriation")]
    [SerializeField] bool varriatePitch = true;
    [SerializeField] float pitchFrom = 0.99f;
    [SerializeField] float pitchTo = 1.01f;

    protected override void Trigger()
    {
        if (varriatePitch)
        {
            audioSource.pitch = Random.Range(pitchFrom, pitchTo);
        }
        foreach (AudioClip audioClip in audioClips)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
