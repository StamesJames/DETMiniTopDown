using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PlayCameraShake : TriggerEffect
{
    [SerializeField] float magnitude, roughness, fadeInTime, fadeOutTime;

    protected override void Trigger()
    {
        CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeInTime, fadeOutTime);
    }
}
