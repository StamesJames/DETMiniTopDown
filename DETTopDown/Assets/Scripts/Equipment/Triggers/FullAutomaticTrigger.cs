using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FullAutomaticTrigger : Trigger
{
    [SerializeField] float timeBetweenTriggers;
    [SerializeField] string buttonToPress;
    [Header("TriggerGroup Stuff")]
    [SerializeField] TriggerGroup triggerGroup;
    [SerializeField] bool sameTimeAsTrigger = true;
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(buttonToPress) && nextShotIn <= 0 && ( !triggerGroup || triggerGroup.TriggersActive ))
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

