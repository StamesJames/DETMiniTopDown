using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTriggerEffect : TriggerEffect
{
    [SerializeField] LayerMask explosionWhatToHit;
    [SerializeField] float explosionRadius;
    [SerializeField] float explosionDamage;
    [SerializeField] float explosionForce;
    [SerializeField] float pushBackTime = 1f;
    [SerializeField] DAMAGETYPE damageType;
    [SerializeField] PrefabPooler explosionEffect;
    [SerializeField] bool destoryThis = true;

    IDamageable myDamageable;

    private void Awake()
    {
        myDamageable = GetComponent<IDamageable>();
    }

    protected override void Trigger()
    {
        Collider2D myCollider = GetComponent<Collider2D>();

        explosionEffect.GetObject(this.transform);
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius, explosionWhatToHit);
        foreach (Collider2D hit in hits)
        {
            IDamageable target = hit.GetComponent<IDamageable>();
            if (target != null && target != myDamageable)
            {
                target.GetPushed((hit.transform.position - this.transform.position).normalized, explosionForce, pushBackTime);
                target.GetDamaged(explosionDamage, damageType);                   
            }               
        }

        if (destoryThis)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0);
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
