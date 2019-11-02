using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressReleasTrigger : Trigger
{
    [SerializeField] string buttonToPressAndReleas;
    [Header("TriggerGroup Stuff")]
    [SerializeField] TriggerGroup triggerGroup;
    [SerializeField] bool inverted = false;
    public override event GetTriggert OnGettingTriggert;
    public event GetTriggert OnReleasTrigger;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(buttonToPressAndReleas))
        {
            if (triggerGroup && triggerGroup.TriggersActive)
            {
                OnGettingTriggert?.Invoke();
            }
            if (triggerGroup)
            {
                triggerGroup.TriggersActive = !inverted;
            }
        }
        if (Input.GetButtonUp(buttonToPressAndReleas))
        {
            OnReleasTrigger?.Invoke();
            if (triggerGroup)
            {
                triggerGroup.TriggersActive = inverted;
            }
        }
    }
}