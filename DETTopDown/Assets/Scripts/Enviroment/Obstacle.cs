using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle :  MonoBehaviour, IEffektGiveable
{
    [SerializeField] PrefabPooler particlePool;


    public PrefabPooler GetDamageEffect()
    {
        return particlePool;
    }

}
