using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TestProjectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifeTime;
    [SerializeField] PrefabPooler projectilePool;
    Rigidbody2D rb;

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
        if (collision.CompareTag("Enemy"))
        {
            IDamageable target = collision.GetComponent<IDamageable>();
            if (target != null)
            {
                target.GetDamaged(20,DAMAGETYPE.NORMAL);
                PrefabPooler particleObject = target.GetDamageEffect();
                GameObject newObject = particleObject.GetObject(transform, collision.transform);

                newObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg + 180));

                newObject.GetComponent<ParticleSystem>().Play();
            }
            projectilePool.PoolObject(this.gameObject);
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

}
