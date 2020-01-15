using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PressAndReleasEffect : TriggerEffect
{
    [SerializeField] PressReleasTrigger releasTrigger;

    private new void OnEnable()
    {
        base.OnEnable();
        if (releasTrigger == null)
        {
            releasTrigger = GetComponent<PressReleasTrigger>();
        }
        releasTrigger.OnReleasTrigger += Releas;
    }

    private new void OnDisable()
    {
        base.OnDisable();
        releasTrigger.OnReleasTrigger -= Releas;
    }

    protected abstract void Releas();
}
