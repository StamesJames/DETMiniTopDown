using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDamage : MonoBehaviour
{
    [SerializeField] DAMAGETYPE damagetype;
    [SerializeField] float damage;
    [SerializeField] LayerMask whatToHit;

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("particle Hit");
        if (((1 << other.gameObject.layer) & whatToHit) > 0)
        {
            IDamageable target = other.GetComponent<IDamageable>();
            if (target != null)
            {
                target.GetDamaged(20, damagetype);
            }
        }
    }

}
