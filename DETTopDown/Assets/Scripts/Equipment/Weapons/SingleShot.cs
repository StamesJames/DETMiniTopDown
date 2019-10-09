using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShot : Weapon
{
    [SerializeField] Transform shotSpawn;
    [SerializeField] GameObject projectile;
    [SerializeField] float fireRate;

    [SerializeField] float shotCd;
    float nextShot = 0;

    private void Start()
    {
        if (fireRate > 0) shotCd = 1 / fireRate;
        else shotCd = float.PositiveInfinity;
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

    public override void Trigger()
    {
        if (shotSpawn && projectile)
        {
            Instantiate(projectile, shotSpawn.position, shotSpawn.rotation);
            nextShot = shotCd;
        }
    }

}
