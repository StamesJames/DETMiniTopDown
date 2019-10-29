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

    protected override void Trigger()
    {
        explosionEffect.GetObject(this.transform);
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius, explosionWhatToHit);
        foreach (Collider2D hit in hits)
        {
            IDamageable target = hit.GetComponent<IDamageable>();
            if (target != null && hit.gameObject != transform.root)
            {
                target.GetPushed((hit.transform.position - this.transform.position).normalized, explosionForce, pushBackTime);
                target.GetDamaged(explosionDamage, damageType);                   
            }               
        } 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0);
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
