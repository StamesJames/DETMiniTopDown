using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MySOBs/RayCastEffects/damage")]
public class DamageRayCastEffect : RayCastEffect
{

    [SerializeField] float damage;
    [SerializeField] DAMAGETYPE damageType;
    [SerializeField] LayerMask whatToDamage;

    public override void TriggerEffect(RaycastHit2D hit)
    {
        if ( ( (1 << hit.collider.gameObject.layer ) & whatToDamage ) > 0)
        {
            IDamageable target = hit.collider.gameObject.GetComponent<IDamageable>();
            if (target != null)
            {
                target.GetDamaged(damage, damageType);
            }
        }
    }
}
