using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDamageInflictor : MonoBehaviour
{
    [SerializeField] DAMAGETYPE damagetype;
    [SerializeField] float damage;
    [SerializeField] string whatToHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(whatToHit))
        {
            IDamageable target = collision.GetComponent<IDamageable>();
            if (target != null)
            {
                target.GetDamaged(20, DAMAGETYPE.NORMAL);
            }
        }
    }
}
