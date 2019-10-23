using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShots : TriggerEffect
{
    [SerializeField] Transform[] shotSpawns;
    [SerializeField] PrefabPooler whatToShoot;


    protected override void Trigger()
    {
        foreach (Transform shotSpawn in shotSpawns)
        {
            whatToShoot.GetObject(shotSpawn);
        }
    }
}
