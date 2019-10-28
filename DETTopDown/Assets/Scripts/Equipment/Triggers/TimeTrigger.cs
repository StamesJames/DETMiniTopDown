using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTrigger : Trigger
{

    [SerializeField] float timeBetweenTriggers;
    [Header("Randomize Stuff")]
    [SerializeField] bool randomize = false;
    [SerializeField] float randomizeRange;
    [Header("TriggerGroup Stuff")]
    [SerializeField] TriggerGroup triggerGroup;
    [SerializeField] bool sameTimeAsTrigger = true;
    [SerializeField] float triggerGroupCD;

    public override event GetTriggert OnGettingTriggert;
    float nextTrigger;

    private void OnValidate()
    {
        if (sameTimeAsTrigger)
        {
            triggerGroupCD = timeBetweenTriggers;
        }
    }

    private void OnEnable()
    {
        nextTrigger = timeBetweenTriggers;
    }

    private void Update()
    {
        if (nextTrigger <= 0)
        {
            OnGettingTriggert?.Invoke();
            if (randomize)
            {
                nextTrigger = timeBetweenTriggers + Random.Range(-randomizeRange, randomizeRange);
            }
            else
            {
                nextTrigger = timeBetweenTriggers;
            }
        }
        else if (nextTrigger > 0)
        {
            nextTrigger -= Time.deltaTime;
        }
    }
}
