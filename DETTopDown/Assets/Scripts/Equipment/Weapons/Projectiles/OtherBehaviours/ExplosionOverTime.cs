using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionOverTime : MonoBehaviour
{
    [SerializeField] LayerMask explosionWhatToHit;
    [SerializeField] float explosionRadius;
    [SerializeField] float explosionDamage;
    [SerializeField] float explosionForce;
    [SerializeField] float explosionTime;
    [SerializeField] DAMAGETYPE damageType;
    [SerializeField] PrefabPooler explosionEffect;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0);
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    private void OnEnable()
    {
        Invoke("Explosion", explosionTime);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Explosion()
    {
        explosionEffect.GetObject(this.transform);
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius, explosionWhatToHit);
        foreach (Collider2D hit in hits)
        {
            IDamageable target = hit.GetComponent<IDamageable>();
            if (target != null)
            {
                target.GetPushed((hit.transform.position - this.transform.position).normalized, explosionForce);
                target.GetDamaged(explosionDamage, damageType);
            }
        }       
    }
}
