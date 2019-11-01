using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : Trigger
{
    [SerializeField] LayerMask whatToTrigger;
    public override event GetTriggert OnGettingTriggert;
    public event GetTriggert ButtonRelese;

    bool ispressed;

    int count;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( ( ( 1 << collision.gameObject.layer ) & whatToTrigger ) > 0)
        {
            count++;
            if (!ispressed)
            {
                OnGettingTriggert?.Invoke();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & whatToTrigger) > 0)
        {
            count--;
            if (count <= 0)
            {
                ButtonRelese?.Invoke();
            }
        }
    }
}
