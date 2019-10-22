using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MySOBs/StatusEffects/DoT")]
public class DoT_SE_SO : StatusEffectSO
{
    [SerializeField] DoT_SE dotStatusEffect;

    public override StatusEffect Fabricate(GameObject target)
    {
        //Debug.Log("DoT_SE fabricated");
        return new DoT_SE(dotStatusEffect, target);
    }
    
}
