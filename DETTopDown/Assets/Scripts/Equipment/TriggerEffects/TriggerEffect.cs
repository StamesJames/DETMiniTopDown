using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerEffect : MonoBehaviour
{
    [SerializeField] protected Trigger triggerToListen;

    protected void OnEnable()
    {
        if (triggerToListen == null)
        {
            triggerToListen = GetComponent<Trigger>();
        }
        if (triggerToListen == null)
        {
            Debug.Log("der TriggerEffect: " + gameObject.name + " hat keinen Trigger");
            return;
        }
        triggerToListen.OnGettingTriggert += Trigger;
    }

    protected void OnDisable()
    {
        if (triggerToListen != null)
        {
            triggerToListen.OnGettingTriggert -= Trigger;
        }
    }

    protected abstract void Trigger();
}
