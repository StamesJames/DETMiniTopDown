using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressReleasTrigger : Trigger
{
    [SerializeField] string buttonToPressAndReleas;

    public override event GetTriggert OnGettingTriggert;
    public event GetTriggert OnReleasTrigger;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(buttonToPressAndReleas))
        {
            OnGettingTriggert?.Invoke();
        }
        if (Input.GetButtonUp(buttonToPressAndReleas))
        {
            OnReleasTrigger?.Invoke();
        }
    }
}