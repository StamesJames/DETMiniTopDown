using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticleEffect : TriggerEffect
{
    [SerializeField] ParticleSystem particleSystem;

    protected override void Trigger()
    {
        particleSystem.Play();
    }

}
