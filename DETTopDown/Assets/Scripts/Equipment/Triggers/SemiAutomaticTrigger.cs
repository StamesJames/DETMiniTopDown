using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SemiAutomaticTrigger : Trigger
{
    [SerializeField] public float timeBetweenTriggers;
    [SerializeField] public string buttonToPress;
    [Header("TriggerGroup Stuff")]
    [SerializeField] public TriggerGroup triggerGroup;
    [SerializeField] bool sameTimeAsTrigger;
    [SerializeField] float triggerGroupCD;


    float nextShotIn;

    public override event GetTriggert OnGettingTriggert;

    private void OnValidate()
    {
        if (sameTimeAsTrigger)
        {
            triggerGroupCD = timeBetweenTriggers;
        }
    }

    private void Start()
    {
        nextShotIn = 0;
        if (sameTimeAsTrigger)
        {
            triggerGroupCD = timeBetweenTriggers;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown(buttonToPress) && nextShotIn <= 0 && (!triggerGroup || triggerGroup.TriggersActive) )
        { 
            OnGettingTriggert?.Invoke();
            nextShotIn = timeBetweenTriggers;
            if (triggerGroup)
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
