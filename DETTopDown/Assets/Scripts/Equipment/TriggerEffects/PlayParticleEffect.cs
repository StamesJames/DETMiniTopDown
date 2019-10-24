using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticleEffect : TriggerEffect
{
    [SerializeField] protected ParticleSystem[] particleSystems;

    protected override void Trigger()
    {
        foreach (ParticleSystem particleSystem in particleSystems)
        {
            particleSystem.Play();
        }
    }

}
