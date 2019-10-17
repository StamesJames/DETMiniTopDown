using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StraightSingleProjectile : Projectile
{

    Rigidbody2D rb;
    [SerializeField] string whatToHit;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        rb.velocity = transform.right * speed;
        Invoke("PoolMe", lifeTime);       
    }


    private void PoolMe()
    {
        projectilePool.PoolObject(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(whatToHit))
        {
            IDamageable target = collision.GetComponent<IDamageable>();
            if (target != null)
            {
                target.GetDamaged(20,DAMAGETYPE.NORMAL);
            }
        }
        if (!collision.CompareTag(this.tag) || collision.CompareTag("Untagged"))
        {
            projectilePool.PoolObject(this.gameObject);
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

}
