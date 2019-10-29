using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalTrigger : Trigger
{
    public override event GetTriggert OnGettingTriggert;

    public void TriggerMe()
    {
        OnGettingTriggert?.Invoke();
    }
}
