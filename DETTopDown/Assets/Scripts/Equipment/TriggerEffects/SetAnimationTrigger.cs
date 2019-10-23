using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimationTrigger : TriggerEffect
{
    [SerializeField] Animator animator;
    [SerializeField] string triggerName;

    protected override void Trigger()
    {
        animator.SetTrigger(triggerName);
    }

}
