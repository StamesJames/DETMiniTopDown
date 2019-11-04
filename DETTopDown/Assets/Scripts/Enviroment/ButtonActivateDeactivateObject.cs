using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivateDeactivateObject : TriggerEffect
{
    [SerializeField] GameObject[] objectsToActivate;
    [SerializeField] bool inverted = false;
    [SerializeField] ButtonTrigger buttonToListen;

    private new void OnEnable()
    {
        base.OnEnable();
        buttonToListen.ButtonRelese += Relese;
    }

    private new void OnDisable()
    {
        base.OnDisable();
        buttonToListen.ButtonRelese -= Relese;
    }


    void Relese()
    {
        foreach (GameObject item in objectsToActivate)
        {
            item.SetActive(inverted);
        }
    }

    protected override void Trigger()
    {
        foreach (GameObject item in objectsToActivate)
        {
            item.SetActive(!inverted);
        }
    }

}
