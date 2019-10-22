using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DoT_SE : StatusEffect
{
    [SerializeField] float damagePerTick;
    [SerializeField] int tickCount;
    [SerializeField] float timeBetweenTicks;
    [SerializeField] DAMAGETYPE damageType;

    float nextTick;
    int currentTickCount = 0;

    public DoT_SE(DoT_SE copieThis ,GameObject target)
    {
        damagePerTick = copieThis.damagePerTick;
        timeBetweenTicks = copieThis.timeBetweenTicks;
        nextTick = timeBetweenTicks;
        damageType = copieThis.damageType;
        this.target = target;
        targetStatusEffectable = target.GetComponent<IStatusEffectable>();
        if (targetStatusEffectable == null)
        {
            Debug.LogError("target " + target.name + " von " + this.name + " hat kein IStatusEffectable. Selbstzertörung eingeleited");
        }
        else
        {
            targetStatusEffectable.AddOnTick(DotTick);
            targetStatusEffectable.AddStatusEffect(this);
        }
    }

    void DotTick()
    {
        if (nextTick <= 0)
        {
            targetStatusEffectable.GetIDamageable().GetDamaged(damagePerTick, damageType);
        }
        else if (nextTick > 0)
        {
            nextTick -= Time.deltaTime;
        }
        currentTickCount++;
        if (currentTickCount >= tickCount)
        {
            RemoveDot();
        }
    }

    void RemoveDot()
    {
        targetStatusEffectable.RemoveOnTick(DotTick);
        targetStatusEffectable.RemoveStatusEffect(this);
    }

    ~DoT_SE()
    {
        targetStatusEffectable.RemoveOnTick(DotTick);
    }

}
