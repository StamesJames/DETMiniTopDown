using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour , IDamageable
{

    [SerializeField] GameObject particleObject;
    ParticleSystem particleSystem;

    private void Awake()
    {
        particleSystem = particleObject.GetComponent<ParticleSystem>();
    }

    public void GetDamaged(float dmg, DAMAGETYPE type)
    {
        Debug.Log("hab dmg bekommen : "+ dmg + type);
    }

    public GameObject GetDamageEffect()
    {
        return particleObject;
    }
}
