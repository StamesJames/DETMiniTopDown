using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccaleratingAnimation : TriggerEffect
{
    [SerializeField] float startSpeed = 0f;
    [SerializeField] float stopSpeed = 1f;
    [SerializeField] Animator anim;

    float currentSpeed;
    AccelleratingFullAutomatic accTrigger;

    protected override void Trigger()
    {
        
    }

    private new void OnEnable()
    {
        base.OnEnable();
        accTrigger = triggerToListen.gameObject.GetComponent<AccelleratingFullAutomatic>();
        currentSpeed = startSpeed;
    }
    

    // Update is called once per frame
    void Update()
    {
        currentSpeed = startSpeed + (stopSpeed - startSpeed) * ( ( accTrigger.CurrentCD - accTrigger.StartTimeBetweenTriggers ) / ( accTrigger.StopTimeBetweenTriggers - accTrigger.StartTimeBetweenTriggers) );
        anim.speed = currentSpeed;
        if (currentSpeed <= startSpeed + 0.01)
        {
            currentSpeed = startSpeed;
        }
    }
}
