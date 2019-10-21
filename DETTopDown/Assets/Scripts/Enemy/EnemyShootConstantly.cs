using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootConstantly : MonoBehaviour
{
    [SerializeField] PrefabPooler whatToShoot;
    [SerializeField] float shotRate;
    [SerializeField] Transform[] shotSpawns;
    [SerializeField] AudioClip shotSound;
    [SerializeField] float soundPitchFrom = 0.98f;
    [SerializeField] float soundPitchTo = 1.02f;

    AudioSource audioSource;
    EnemyMasterAI masterAI;
    bool isShooting;
    float shotCD;
    float nextShot = 0;

    private void Awake()
    {
        if (shotRate > 0)
        {
            shotCD = (1 / shotRate) * 60;
        }
        else
        {
            shotCD = float.PositiveInfinity;
        }

        audioSource = GetComponent<AudioSource>();
        masterAI = GetComponent<EnemyMasterAI>();
    }

    private void OnEnable()
    {
        masterAI.onTargetFound += OnTargetFound;
    }

    private void OnDisable()
    {
        masterAI.onTargetFound -= OnTargetFound;
    }

    void OnTargetFound(GameObject target)
    {
        if (target != null)
        {
            isShooting = true;
        }
        else
        {
            isShooting = false;
        }
    }

    private void Update()
    {
        if (isShooting)
        {
            if (nextShot <= 0)
            {
                foreach (Transform shotSpawn in shotSpawns)
                {
                    whatToShoot.GetObject(shotSpawn);
                    audioSource.pitch = Random.Range(soundPitchFrom, soundPitchTo);
                    audioSource.PlayOneShot(shotSound);
                }
                nextShot = shotCD;
            }
            else if (nextShot > 0)
            {
                nextShot -= Time.deltaTime;
            }
        }
    }
}
