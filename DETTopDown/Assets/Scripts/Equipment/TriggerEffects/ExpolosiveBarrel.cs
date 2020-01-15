using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpolosiveBarrel : TriggerEffect
{
    [SerializeField] LayerMask explosionWhatToHit;
    [SerializeField] float explosionRadius;
    [SerializeField] float explosionDamage;
    [SerializeField] float explosionForce;
    [SerializeField] float pushBackTime = 1f;
    [SerializeField] DAMAGETYPE damageType;
    [SerializeField] PrefabPooler explosionEffect;
    [SerializeField] float timeToExplode;
    [SerializeField] string animationBool;

    IDamageable myDamageable;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        myDamageable = GetComponent<IDamageable>();
    }

    bool goingToExplode = false;

    protected override void Trigger()
    {
        if (!goingToExplode)
        {
            goingToExplode = true;
            anim.SetBool(animationBool, true);
            Invoke("Explosion", timeToExplode);
        }
    }

    private new void OnDisable()
    {
        base.OnDisable();
        CancelInvoke();
    }

    void Explosion()
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

        Destroy(this.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0);
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
