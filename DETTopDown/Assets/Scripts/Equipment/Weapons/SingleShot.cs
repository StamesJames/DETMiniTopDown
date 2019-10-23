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
    [SerializeField] AudioClip shotSound;
    [SerializeField] float soundPitchFrom = 0.8f;
    [SerializeField] float soundPitchTo = 1.2f;
    [Header("Camera Shake Kram")]
    [SerializeField] float magnitude = 4f;
    [SerializeField] float roughness = 4f;
    [SerializeField] float fadeInTime = 1f;
    [SerializeField] float fadeOutTime = 1f;

    AudioSource audioSource;
    float shotCd;
    float nextShot = 0;
    Animator anim;

    private void Awake()
    {
        //Der Animator ist dazu dar die Rückstoß animation zu spielen 
        anim = GetComponent<Animator>();
        //AudioScource um den Schusssound zu spielen 
        audioSource = GetComponent<AudioSource>();
    }

    //Das ist nur für den edito, das ist wenn im Editor der Wer geändert wird wird das aufgerufen
    private void OnValidate()
    {
        if (fireRate > 0) shotCd = 1 / fireRate * 60;
    }

    private void Start()
    {
        //Berechnen der zeit die zwischen den Schüssen sein muss um die gewünschte Schussrate zu erhalten
        if (fireRate > 0) shotCd = 1 / fireRate * 60;
        else shotCd = float.PositiveInfinity;
    }

    private void Update()
    {
        //Abfrage ob der Feuer knopf Gedrück wurde und ob der Cooldown schon runter ist. Wür die Maschinen Pistole müsstest du dann hier GetButton("Fire1") nutzen können 
        if (Input.GetButtonDown("Fire1") && nextShot <= 0)
        {
            Trigger();
        }
        else if (nextShot > 0) //wenn der Cooldown der waffe noch tickt dann hier die zeit runter zählen 
        {
            nextShot -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        //Diese Fumktion zielt die angegebene transform (Also hier einfach die Eigene) zur mousposition 
        AimWeapon.Instance.Aim(transform);
    }

    public override void Trigger()
    {
        if (shotSpawn && projectilePool && !PauseMenu.Instance.IsPaused)
        {
            //Diese Funktion Spawned ein Object aus dem gegebenen PrefabPool
            projectilePool.GetObject(shotSpawn);
            //resetten des cooldown für den nächsten Schuss
            nextShot = shotCd;
            //das ist alles nur effekt kram also Rückstoß animation, CameraShake, Mündungsfeuer, SoundPitch abwechseln damit es nicht so monoton ist, sound abspeielen (in der Reihenfole)
            anim.SetTrigger("Shoot");
            CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeInTime, fadeOutTime);
            shotParticles.Play();
            audioSource.pitch = Random.Range(soundPitchFrom, soundPitchTo);
            audioSource.PlayOneShot(shotSound);

        }       
    }

}
