using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShot : Weapon
{
    [SerializeField] Transform shotSpawn;
    [SerializeField] GameObject projectile;
    [SerializeField] float fireRate;

    float shotCd;
    float nextShot = 0;
    AimWeapon aimer;


    private void Start()
    {
        if (fireRate > 0) shotCd = 1 / fireRate;
        else shotCd = float.PositiveInfinity;
        aimer = new AimWeapon();
    }

    private void Update()
    {

        if (Input.GetButtonDown("Fire1") && nextShot <= 0)
        {
            Trigger();
        }
        else if (nextShot > 0)
        {
            nextShot -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        aimer.Aim(transform);
    }

    public override void Trigger()
    {
        if (shotSpawn && projectile)
        {
            Instantiate(projectile, shotSpawn.position, shotSpawn.rotation);
            nextShot = shotCd;
        }
    }

}
