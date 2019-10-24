using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAndStopParticleEffect : PressAndReleasEffect
{
    [SerializeField] ParticleSystem particleSystem;

    protected override void Releas()
    {
        particleSystem.Stop();
    }

    protected override void Trigger()
    {
        particleSystem.Play();
    }
}
