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
    [SerializeField] bool randomizeTime = false;
    [SerializeField] float randomRange;
    [SerializeField] float pushBackTime = 1f;
    [SerializeField] DAMAGETYPE damageType;
    [SerializeField] PrefabPooler explosionEffect;
    [SerializeField] bool destroy = true;
    [SerializeField] int destroyAfterExplosionCount = 1;

    int currentExplosionCount;
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

    private void OnEnable()
    {
        currentExplosionCount = 0;
        Invoke("Explosion", explosionTime + ( randomizeTime ? Random.Range(-randomRange, randomRange) : 0 ) );
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Explosion()
    {
        currentExplosionCount++;
        explosionEffect.GetObject(this.transform);
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius, explosionWhatToHit);
        foreach (Collider2D hit in hits)
        {
            IDamageable target = hit.GetComponent<IDamageable>();
            if (target != null)
            {
                target.GetPushed((hit.transform.position - this.transform.position).normalized, explosionForce,pushBackTime);
                target.GetDamaged(explosionDamage, damageType);
            }
        }
        if (currentExplosionCount >= destroyAfterExplosionCount && destroy)
        {
            selfPooler.PoolMe();
        }
    }
}
