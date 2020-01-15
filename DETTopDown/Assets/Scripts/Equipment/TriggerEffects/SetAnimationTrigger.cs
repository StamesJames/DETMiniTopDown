using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimationTrigger : TriggerEffect
{
    [SerializeField] Animator animator;
    [SerializeField] string[] triggerNames;

    protected override void Trigger()
    {
        foreach (string triggerName in triggerNames)
        {
            animator.SetTrigger(triggerName);
        }
    }

}
