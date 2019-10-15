using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] PrefabPooler particlePool;
    [SerializeField] float startHealth;
    float lifetotal;

    [Header("Unity Stuff")]
    [SerializeField] Image healthBar;

    void Awake(){
        lifetotal = startHealth;
        healthBar.fillAmount = lifetotal/startHealth;
    }


    public void GetDamaged(float dmg, DAMAGETYPE type)
    {
        Debug.Log("hab dmg bekommen : "+ dmg + type);
        lifetotal -= dmg;

        healthBar.fillAmount = lifetotal/startHealth;

        if(lifetotal <= 0){
            DestroyMe();
        }
    }

    public PrefabPooler GetDamageEffect()
    {
        return particlePool;
    }
    public void DestroyMe(){
        Destroy(gameObject);
    }
}
