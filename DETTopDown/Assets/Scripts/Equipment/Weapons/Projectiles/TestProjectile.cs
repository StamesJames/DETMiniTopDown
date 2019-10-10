using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TestProjectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifeTime;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(this.gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable target = collision.GetComponent<IDamageable>();
        if (target != null)
        {
            target.GetDamaged(20,DAMAGETYPE.NORMAL);
            GameObject particleObject = target.GetDamageEffect();
            particleObject.transform.position = this.transform.position;

            particleObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(rb.velocity.y, rb.velocity.x) + 180));

            particleObject.GetComponent<ParticleSystem>().Play();
        }

        
        Destroy(this.gameObject);
    }

}
