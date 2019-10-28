using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitTrigger : Trigger
{
    [SerializeField] LayerMask whichHitTriggers;

    public override event GetTriggert OnGettingTriggert;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (((1 << collision.gameObject.layer) & whichHitTriggers) > 0)
        {
            OnGettingTriggert?.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & whichHitTriggers) > 0)
        {
            OnGettingTriggert?.Invoke();
        }
    }
}
