using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHitEffectPlayer : MonoBehaviour
{
    [SerializeField] LayerMask whatToHit;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & whatToHit) > 0)
        {
            IEffektGiveable target = collision.gameObject.GetComponent<IEffektGiveable>();

            if (target != null)
            {
                PrefabPooler particleObject = target.GetDamageEffect();
                GameObject newObject = particleObject.GetObject(transform, collision.transform);
                newObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg + 180));
                newObject.GetComponent<ParticleSystem>().Play();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & whatToHit) > 0)
        {
            IEffektGiveable target = collision.gameObject.GetComponent<IEffektGiveable>();

            if (target != null)
            {
                PrefabPooler particleObject = target.GetDamageEffect();
                GameObject newObject = particleObject.GetObject(transform, collision.transform);
                newObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg + 180));
                newObject.GetComponent<ParticleSystem>().Play();
            }
        }
    }
}
