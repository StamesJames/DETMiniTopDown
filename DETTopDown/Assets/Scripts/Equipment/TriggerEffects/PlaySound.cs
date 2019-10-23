using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : TriggerEffect
{
    [SerializeField] AudioClip soundToPlay;
    [SerializeField] AudioSource audioSource;
    [Header("Sound Pitch varriation")]
    [SerializeField] bool varriatePitch = true;
    [SerializeField] float pitchFrom = 0.95f;
    [SerializeField] float pitchTo = 1.05f;

    protected override void Trigger()
    {
        if (varriatePitch)
        {
            audioSource.pitch = Random.Range(pitchFrom, pitchTo);
        }
        audioSource.PlayOneShot(soundToPlay);
    }
}
