using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraplingHook : TriggerEffect
{
    [SerializeField] float maxLeangth;
    [SerializeField] float pullSpeed;
    [SerializeField] float shootSpeed;
    [SerializeField] float stopDistance;
    [SerializeField] LineRenderer chain;
    [SerializeField] Hook hook;
    [SerializeField] Transform shotSpawn;

    PlayerMovement playerMovement;
    HOOKSTATE state = HOOKSTATE.INAKTIVE;

    delegate void HookAction();
    HookAction hookTriggerAction;
    HookAction hookUpdateAction;

    private void Awake()
    {
        playerMovement = transform.root.GetComponent<PlayerMovement>();
        hook.Speed = shootSpeed;
        hookTriggerAction = InaktiveTrigger;
    }

    private void Update()
    {
        hookUpdateAction?.Invoke();
    }

    protected override void Trigger()
    {
        hookTriggerAction?.Invoke();
    }

    void InaktiveTrigger()
    {
        Shoot();
    }

    void InaktiveUpdate()
    {

    }

    void ShootingTrigger()
    {

    }

    void ShootingUpdate()
    {
        if ((transform.position - hook.transform.position).magnitude > maxLeangth) StopShooting();
        UpdateChain();
    }

    void PullingTrigger()
    {
        StopPulling();
    }

    void PullingUpdate()
    {
        playerMovement.MovePlayer((hook.transform.position - transform.position).normalized, pullSpeed);
        if ((hook.transform.position - transform.position).magnitude <= stopDistance)
        {
            StopPulling();
        }
        UpdateChain();
    }

    void UpdateChain()
    {
        chain.SetPosition(0, transform.position);
        chain.SetPosition(1, hook.transform.position);
    }

    void StopPulling()
    {
        Debug.Log("Stop Pulling");
        playerMovement.InputActive = true;
        hook.gameObject.SetActive(false);
        chain.gameObject.SetActive(false);
        hookTriggerAction = InaktiveTrigger;
        hookUpdateAction = InaktiveUpdate;
        state = HOOKSTATE.INAKTIVE;
    }

    void StopShooting()
    {
        Debug.Log("Stop shooting");
        playerMovement.InputActive = true;
        hook.gameObject.SetActive(false);
        chain.gameObject.SetActive(false);
        hookTriggerAction = InaktiveTrigger;
        hookUpdateAction = InaktiveUpdate;
        state = HOOKSTATE.INAKTIVE;
    }



    void Shoot()
    {
        hook.transform.position = shotSpawn.position;
        hook.transform.rotation = shotSpawn.rotation;
        hook.transform.SetParent(null);
        UpdateChain();
        chain.gameObject.SetActive(true);
        hook.gameObject.SetActive(true);
        hookTriggerAction = ShootingTrigger;
        hookUpdateAction = ShootingUpdate;
        state = HOOKSTATE.SHOOTING;
    }

    public void HookHit()
    {
        Debug.Log("Hook Hit");
        playerMovement.InputActive = false;
        playerMovement.MovePlayer((hook.transform.position - transform.position).normalized, pullSpeed);
        hookTriggerAction = PullingTrigger;
        hookUpdateAction = PullingUpdate;
        state = HOOKSTATE.PULLING;
    }

    enum HOOKSTATE
    {
        INAKTIVE, SHOOTING, PULLING
    }
}
