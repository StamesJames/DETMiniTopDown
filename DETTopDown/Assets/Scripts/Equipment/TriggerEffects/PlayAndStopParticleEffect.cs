using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAndStopParticleEffect : PressAndReleasEffect
{
    [SerializeField] ParticleSystem[] particleSystems;

    protected override void Releas()
    {
        foreach (ParticleSystem particleSystem in particleSystems)
        {
            particleSystem.Stop();
        }
    }

    protected override void Trigger()
    {
        foreach (ParticleSystem particleSystem in particleSystems)
        {
            particleSystem.Play();
        }
    }
}
