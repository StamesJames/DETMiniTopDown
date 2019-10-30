using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSquare : TriggerEffect
{
    [SerializeField] float howBig;
    [SerializeField] LayerMask whatToHit;
    [SerializeField] float damage;
    [SerializeField] DAMAGETYPE damageType;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(howBig, howBig, howBig));
    }

    protected override void Trigger()
    {
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, new Vector2(howBig, howBig), 0, whatToHit);
        foreach (Collider2D hit in hits)
        {
            IDamageable hitDamageable = hit.GetComponent<IDamageable>();
            if (hitDamageable != null)
            {
                hitDamageable.GetDamaged(damage, damageType);
            }
        }
    }

}
