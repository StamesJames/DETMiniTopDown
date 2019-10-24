using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGroup : MonoBehaviour
{
    bool triggersActive = true;

    public bool TriggersActive { get => triggersActive; set => triggersActive = value; }

    float currentCD;

    public void SetCD(float countDown)
    {
        triggersActive = false;
        currentCD = countDown;
    }

    private void Update()
    {
        if (!triggersActive)
        {
            if (currentCD <= 0)
            {
                triggersActive = true;
            }
            else if (currentCD > 0)
            {
                currentCD -= Time.time;
            }
        }
    }
}
