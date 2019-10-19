using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShot : Weapon
{
    [SerializeField] Transform shotSpawn;
    [Tooltip("Fire Rate in shots / min")]
    [Header("Shot Rate in shots / min")]
    [SerializeField] float fireRate;
    [SerializeField] PrefabPooler projectilePool;

    float shotCd;
    float nextShot = 0;

    private void OnValidate()
    {
        if (fireRate > 0) shotCd = 1 / fireRate * 60;
    }

    private void Start()
    {
        if (fireRate > 0) shotCd = 1 / fireRate * 60;
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

    private void FixedUpdate()
    {
        AimWeapon.Instance.Aim(transform);
    }

    public override void Trigger()
    {
        if (shotSpawn && projectilePool && !PauseMenu.Instance.IsPaused)
        {
            projectilePool.GetObject(shotSpawn);
            nextShot = shotCd;
        }       
    }

}
