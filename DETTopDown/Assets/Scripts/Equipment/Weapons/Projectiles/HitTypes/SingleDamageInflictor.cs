using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDamageInflictor : MonoBehaviour
{
    [SerializeField] DAMAGETYPE damagetype;
    [SerializeField] float damage;
    [SerializeField] LayerMask whatToHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & whatToHit) > 0)
        {
            IDamageable target = collision.GetComponent<IDamageable>();
            if (target != null)
            {
                target.GetDamaged(20, damagetype);
            }
        }
    }
}
