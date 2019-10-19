using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraplingHook : Gadget
{
    [SerializeField] float maxLeangth;
    [SerializeField] float pullSpeed;
    [SerializeField] float shootSpeed;
    [SerializeField] float stopDistance;
    [SerializeField] LineRenderer chain;
    [SerializeField] Hook hook;
    [SerializeField] Transform aimTransform;
    [SerializeField] Transform shotSpawn;

    PlayerMovement playerMovement;
    HOOKSTATE state = HOOKSTATE.INAKTIVE;

    delegate void HookAction();
    HookAction hookAction;

    private void Awake()
    {
        playerMovement = transform.root.GetComponent<PlayerMovement>();
        hook.Speed = shootSpeed;
        hookAction = Inaktive;
    }

    void Inaktive()
    {
        if (Input.GetButtonDown("Fire2")) Trigger();
    }

    void Shooting()
    {
        if ((transform.position - hook.transform.position).magnitude > maxLeangth) StopShooting();
        UpdateChain();
    }

    void Pulling()
    {
        if ((hook.transform.position - transform.position).magnitude <= stopDistance)
        {
            StopPulling();
        }
        UpdateChain();
    }

    private void Update()
    {
        hookAction?.Invoke();
        /*
        if (state.Equals(HOOKSTATE.INAKTIVE))
        {
            if (Input.GetButtonDown("Fire2")) Trigger();
            
        }
        else if (state.Equals(HOOKSTATE.SHOOTING))
        {
            if ((transform.position - hook.transform.position).magnitude > maxLeangth) StopShooting();
            UpdateChain();   
        }
        else if (state.Equals(HOOKSTATE.PULLING))
        {
            if ((hook.transform.position - transform.position).magnitude <= stopDistance)
            {
                StopPulling();
            }
            UpdateChain();
        }
        */
        AimWeapon.Instance.Aim(aimTransform);
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
        hookAction = Inaktive;
        state = HOOKSTATE.INAKTIVE;
    }

    void StopShooting()
    {
        Debug.Log("Stop shooting");
        playerMovement.InputActive = true;
        hook.gameObject.SetActive(false);
        chain.gameObject.SetActive(false);
        hookAction = Inaktive;
        state = HOOKSTATE.INAKTIVE;
    }

    public override void Trigger()
    {
        hook.transform.position = shotSpawn.position;
        hook.transform.rotation = shotSpawn.rotation;
        hook.transform.SetParent(transform);
        chain.gameObject.SetActive(true);
        hook.gameObject.SetActive(true);
        chain.SetPosition(0, transform.position);
        chain.SetPosition(1, hook.transform.position);
        hookAction = Shooting;
        state = HOOKSTATE.SHOOTING;
    }

    public void HookHit()
    {
        Debug.Log("Hook Hit");
        playerMovement.InputActive = false;
        playerMovement.MovePlayer((hook.transform.position - transform.position).normalized, pullSpeed);
        hookAction = Pulling;
        state = HOOKSTATE.PULLING;
    }

    enum HOOKSTATE
    {
        INAKTIVE, SHOOTING, PULLING
    }
}
