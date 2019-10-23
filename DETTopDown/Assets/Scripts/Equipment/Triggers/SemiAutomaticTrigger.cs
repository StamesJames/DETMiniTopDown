using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiAutomaticTrigger : Trigger
{
    [SerializeField] float timeBetweenTriggers;
    [SerializeField] string buttonToPress;

    float nextShotIn;

    public override event GetTriggert OnGettingTriggert;

    private void Start()
    {
        nextShotIn = 0;
    }

    private void Update()
    {
        if (Input.GetButtonDown(buttonToPress) && nextShotIn <= 0)
        {
            OnGettingTriggert?.Invoke();
            nextShotIn = timeBetweenTriggers;
        }
        else if (nextShotIn > 0)
        {
            nextShotIn -= Time.deltaTime;
        }
    }

}
