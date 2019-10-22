using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectOnHit : MonoBehaviour
{
    [SerializeField] StatusEffectSO[] statusEffects;
    [SerializeField] LayerMask whatToHit;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & whatToHit ) > 0)
        {
            foreach (StatusEffectSO statusEffect in statusEffects)
            {
                statusEffect.Fabricate(collision.gameObject);
            }
        }
    }
}
