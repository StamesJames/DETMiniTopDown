using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingTrigger : Trigger
{
    [SerializeField] string buttonToPress;
    [SerializeField] float loadingTime;
    [SerializeField] float unloadTime;
    [SerializeField] bool automaticlyTriggerWhenFull;

    float currentLoadPercent;
    float loadRate;
    float unloadRate;

    public float CurrentLoadPercent { get => currentLoadPercent; set => currentLoadPercent = value; }

    public delegate void OnLoadPercentChange(float currentLoadPercent);
    public event OnLoadPercentChange onLoadPercentChange;

    public override event GetTriggert OnGettingTriggert;

    // Start is called before the first frame update
    void Start()
    {
        if (loadingTime > 0 )
        {
            loadRate = 100 / loadingTime;
        }
        else
        {
            loadRate = 0;
        }

        if (unloadTime > 0)
        {
            unloadTime = 100 / loadingTime;
        }
        else
        {
            unloadRate = float.PositiveInfinity;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (currentLoadPercent >= 100 && automaticlyTriggerWhenFull)
        {
            OnGettingTriggert?.Invoke();
            currentLoadPercent = 0;
            onLoadPercentChange?.Invoke(currentLoadPercent);
        }
        else if (currentLoadPercent >= 100 && Input.GetButtonUp(buttonToPress))
        {
            OnGettingTriggert?.Invoke();
            currentLoadPercent = 0;
            onLoadPercentChange?.Invoke(currentLoadPercent);
        }

        if (Input.GetButton(buttonToPress) && currentLoadPercent < 100)
        {
            currentLoadPercent = Mathf.Clamp(currentLoadPercent + loadRate * Time.deltaTime, 0, 100);
            onLoadPercentChange?.Invoke(currentLoadPercent);
        }
        else if (!Input.GetButton(buttonToPress) && currentLoadPercent > 0)
        {
            currentLoadPercent = Mathf.Clamp(currentLoadPercent - unloadRate * Time.deltaTime, 0, 100);
            onLoadPercentChange?.Invoke(currentLoadPercent);
        }



    }
}
