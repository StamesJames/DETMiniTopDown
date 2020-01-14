using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionOnHit : MonoBehaviour
{

    [SerializeField] LayerMask whatToHit;
    [SerializeField] LayerMask explosionWhatToHit;
    [SerializeField] float explosionRadius;
    [SerializeField] float explosionDamage;
    [SerializeField] float explosionForce;
    [SerializeField] float pushBackTime = 1f;
    [SerializeField] DAMAGETYPE damageType;
    [SerializeField] PrefabPooler explosionEffect;
    [SerializeField] bool destroy = true;

    SelfPooler selfPooler;

    private void Awake()
    {
        selfPooler = GetComponent<SelfPooler>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0);
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( ((1 << collision.gameObject.layer) & whatToHit) > 0)
        {
            explosionEffect.GetObject(this.transform);
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius, explosionWhatToHit);
            foreach (Collider2D hit in hits)
            {
                IDamageable target = hit.GetComponent<IDamageable>();
                if (target != null)
                {
                    target.GetPushed((hit.transform.position - this.transform.position).normalized, explosionForce, pushBackTime);
                    target.GetDamaged(explosionDamage, damageType);                   
                }               
            }
            if (destroy)
            {
                selfPooler.PoolMe();
            }
        }
    }
}
