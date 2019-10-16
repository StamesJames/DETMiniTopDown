using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraplingHook : Gadget
{
    [SerializeField] GameObject chain;
    [SerializeField] float maxLeangth;
    [SerializeField] float shotSpeed;
    [SerializeField] float pullSpeed;
    [SerializeField] GameObject hook;
    [SerializeField] Transform aimTransform;
    [SerializeField] Transform shotSpawn;

    PlayerMovement playerMovement;
    bool isShooting;
    bool isPulling;
    AimWeapon aimer;
    LineRenderer chainRenderer;

    private void Awake()
    {
        playerMovement = transform.root.GetComponent<PlayerMovement>();
        chainRenderer = chain.GetComponent<LineRenderer>();
        aimer = new AimWeapon();
    }

    private void Update()
    {
        chainRenderer.SetPosition(0, transform.position);    
        chainRenderer.SetPosition(1, hook.transform.position);
        if (Input.GetButtonDown("Fire2") && !isShooting)
        {
            Trigger();
        }
        else if (Input.GetButtonDown("Fire2") && isShooting)
        {
            StopShooting();
        }

        if (isPulling)
        {
            playerMovement.InputActive = false;
            playerMovement.MovePlayer((hook.transform.position - transform.position).normalized, pullSpeed);
            if ((hook.transform.position - transform.position).magnitude <= 0.5f)
            {
                StopPulling();
            }
        }
        aimer.Aim(aimTransform);
    }

    void StopPulling()
    {
        hook.SetActive(false);
        chain.SetActive(false);
        playerMovement.InputActive = true;
        isPulling = false;
        StopShooting();
    }

    void StopShooting()
    {
        hook.SetActive(false);
        chain.SetActive(false);
        isShooting = false;
    }

    public override void Trigger()
    {
        hook.transform.position = shotSpawn.position;
        hook.transform.rotation = shotSpawn.rotation;
        chain.SetActive(true);
        hook.SetActive(true);
        hook.transform.SetParent(transform);
        chainRenderer.SetPosition(0, transform.position);
        chainRenderer.SetPosition(1, hook.transform.position);
        isShooting = true;
    }

    public void HookHit()
    {
        Debug.Log("Hook Hit");
        isShooting = false;
        isPulling = true;
    }
}
