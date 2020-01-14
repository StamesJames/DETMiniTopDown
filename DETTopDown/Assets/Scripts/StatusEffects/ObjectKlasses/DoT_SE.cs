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
    [SerializeField] GameObject effectVisuals;

    float nextTick;
    int currentTickCount = 0;
    GameObject currentVisualEffect;


    public DoT_SE(DoT_SE copieThis ,GameObject target)
    {
        damagePerTick = copieThis.damagePerTick;
        tickCount = copieThis.tickCount;
        timeBetweenTicks = copieThis.timeBetweenTicks;
        nextTick = timeBetweenTicks;
        damageType = copieThis.damageType;
        effectVisuals = copieThis.effectVisuals;
        blockedBy = copieThis.blockedBy;

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
        currentVisualEffect = GameObject.Instantiate(effectVisuals, target.transform);
    }

    void DotTick()
    {
        //Debug.Log("Current Tick count: " + currentTickCount);
        if (nextTick <= 0)
        {
            //Debug.Log("Dot hat getickt und hat target: " + target.name);
            targetStatusEffectable.GetIDamageable().GetDamaged(damagePerTick, damageType);
            nextTick = timeBetweenTicks;
            currentTickCount++;
        }
        else if (nextTick > 0)
        {
            //Debug.Log("Next Tick in: " + nextTick);
            nextTick -= Time.deltaTime;
        }
        if (currentTickCount >= tickCount)
        {
            RemoveEffect();
        }
    }

    public override void RemoveEffect()
    {
        Debug.Log("dot got removed");
        targetStatusEffectable.RemoveOnTick(DotTick);
        targetStatusEffectable.RemoveStatusEffect(this);
        GameObject.Destroy(currentVisualEffect);
    }

    ~DoT_SE()
    {
        Debug.Log("Dot Effect got destructed");
        targetStatusEffectable.RemoveOnTick(DotTick);
    }

}
