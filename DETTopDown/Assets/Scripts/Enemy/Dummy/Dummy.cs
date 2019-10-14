using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour , IDamageable
{
    [SerializeField] PrefabPooler particlePool;


    public void GetDamaged(float dmg, DAMAGETYPE type)
    {
        Debug.Log("hab dmg bekommen : "+ dmg + type);
    }

    public PrefabPooler GetDamageEffect()
    {
        return particlePool;
    }
}
