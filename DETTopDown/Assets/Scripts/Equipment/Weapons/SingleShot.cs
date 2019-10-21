using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class SingleShot : Weapon
{
    [SerializeField] Transform shotSpawn;
    [Tooltip("Fire Rate in shots / min")]
    [Header("Shot Rate in shots / min")]
    [SerializeField] float fireRate;
    [SerializeField] PrefabPooler projectilePool;
    [Header("EffectsStuff")]
    [SerializeField] ParticleSystem shotParticles;
    [Header("Camera Shake Kram")]
    [SerializeField] float magnitude = 4f;
    [SerializeField] float roughness = 4f;
    [SerializeField] float fadeInTime = 1f;
    [SerializeField] float fadeOutTime = 1f;


    float shotCd;
    float nextShot = 0;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

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
            anim.SetTrigger("Shoot");
            CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeInTime, fadeOutTime);
            shotParticles.Play();
        }       
    }

}
