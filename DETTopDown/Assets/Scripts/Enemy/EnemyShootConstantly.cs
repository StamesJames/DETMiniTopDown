using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootConstantly : MonoBehaviour
{
    [SerializeField] PrefabPooler whatToShoot;
    [SerializeField] float shotRate;
    [SerializeField] Transform[] shotSpawns;

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
