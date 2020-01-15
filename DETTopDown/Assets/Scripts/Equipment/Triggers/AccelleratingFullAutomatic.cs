using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelleratingFullAutomatic : Trigger
{
    [SerializeField] float startTimeBetweenTriggers;
    [SerializeField] float stopTimeBetweenTriggers;
    [SerializeField] float accelerationSpeed = 0.3f;
    [SerializeField] float decelerationSpeed = 0.3f;
    [SerializeField] string buttonToPress;
    [Header("TriggerGroup Stuff")]

    float currentCD; 
    float nextShotIn;

    public float CurrentCD { get => currentCD; }
    public float StartTimeBetweenTriggers { get => startTimeBetweenTriggers; }
    public float StopTimeBetweenTriggers { get => stopTimeBetweenTriggers; }

    public override event GetTriggert OnGettingTriggert;

    private void Awake()
    {
        nextShotIn = startTimeBetweenTriggers;
        currentCD = startTimeBetweenTriggers;
    }

    private void Update()
    {
        if (Input.GetButton(buttonToPress))
        {
            currentCD = Mathf.Lerp(currentCD, stopTimeBetweenTriggers, accelerationSpeed * Time.deltaTime);
            if (nextShotIn <= 0)
            {
                OnGettingTriggert?.Invoke();
                nextShotIn = currentCD;
            }
        }
        else
        {
            currentCD = Mathf.Lerp(currentCD, startTimeBetweenTriggers, decelerationSpeed * Time.deltaTime);
        }

        if (nextShotIn > 0)
        {
            nextShotIn -= Time.deltaTime;
        }
    }




}
