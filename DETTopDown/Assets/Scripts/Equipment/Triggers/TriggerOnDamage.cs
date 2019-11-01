using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnDamage : Trigger, IDamageable
{
    public override event GetTriggert OnGettingTriggert;

    public void GetDamaged(float dmg, DAMAGETYPE type)
    {
        if(dmg > 0 ){
            OnGettingTriggert?.Invoke();
        }
    }

    public void GetPushed(Vector2 direction, float force, float stunTime)
    {
        
    }
}
