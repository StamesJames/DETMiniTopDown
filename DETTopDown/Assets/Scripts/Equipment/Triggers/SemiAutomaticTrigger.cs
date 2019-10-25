using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiAutomaticTrigger : Trigger
{
    [SerializeField] float timeBetweenTriggers;
    [SerializeField] string buttonToPress;
    [Header("TriggerGroup Stuff")]
    [SerializeField] TriggerGroup triggerGroup;
    [SerializeField] float triggerGroupCD;


    float nextShotIn;

    public override event GetTriggert OnGettingTriggert;

    private void Start()
    {
        nextShotIn = 0;
    }

    private void Update()
    {
        if (Input.GetButtonDown(buttonToPress) && nextShotIn <= 0 && (triggerGroup == null || triggerGroup.TriggersActive) )
        { 
            OnGettingTriggert?.Invoke();
            nextShotIn = timeBetweenTriggers;
            if (triggerGroup != null)
            {
                triggerGroup.SetCD(triggerGroupCD);
            }
        }
        else if (nextShotIn > 0)
        {
            nextShotIn -= Time.deltaTime;
        }
    }

}
