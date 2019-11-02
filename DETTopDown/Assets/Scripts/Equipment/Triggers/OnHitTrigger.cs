using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitTrigger : Trigger
{
    [SerializeField] LayerMask whichHitTriggers;
    [SerializeField] bool alsoTriggerOnExit;
    [SerializeField] bool onlyTriggerOnce = false;

    Collider2D colliderTriggert;

    bool allreadyTriggered = false;

    public Collider2D ColliderTriggert { get => colliderTriggert; set => colliderTriggert = value; }

    public override event GetTriggert OnGettingTriggert;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (((1 << collision.gameObject.layer) & whichHitTriggers) > 0 && (!onlyTriggerOnce || !allreadyTriggered))
        {
            OnGettingTriggert?.Invoke();
            allreadyTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (alsoTriggerOnExit)
        {
            if (((1 << collision.gameObject.layer) & whichHitTriggers) > 0 && (!onlyTriggerOnce || !allreadyTriggered))
            {
                OnGettingTriggert?.Invoke();
                allreadyTriggered = true;

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & whichHitTriggers) > 0 && (!onlyTriggerOnce || !allreadyTriggered))
        {
            OnGettingTriggert?.Invoke();
            allreadyTriggered = true;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (alsoTriggerOnExit)
        {
            if (((1 << collision.gameObject.layer) & whichHitTriggers) > 0 && (!onlyTriggerOnce || !allreadyTriggered))
            {
                OnGettingTriggert?.Invoke();
                allreadyTriggered = true;

            }
        }
    }
}
