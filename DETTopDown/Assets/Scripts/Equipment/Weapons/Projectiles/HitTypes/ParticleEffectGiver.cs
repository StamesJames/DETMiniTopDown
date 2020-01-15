using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectGiver : MonoBehaviour
{
    [SerializeField] StatusEffectSO[] statusEffects;
    [SerializeField] LayerMask whatToHit;

    private void OnParticleCollision(GameObject collision)
    {
        if (((1 << collision.gameObject.layer) & whatToHit) > 0)
        {
            foreach (StatusEffectSO statusEffect in statusEffects)
            {
                statusEffect.Fabricate(collision.gameObject);
            }
        }
    }
}
