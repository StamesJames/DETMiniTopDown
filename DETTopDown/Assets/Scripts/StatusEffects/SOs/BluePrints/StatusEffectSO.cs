using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffectSO : ScriptableObject
{
    public abstract StatusEffect Fabricate(GameObject target);
}
