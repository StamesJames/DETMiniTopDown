using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dummy : MonoBehaviour , IDamageable
{
    [SerializeField] PrefabPooler particlePool;
    [SerializeField] float lifetotal;
    [SerializeField] float startHealth;

    [Header("Unity Stuff")]
    public Image healthBar;

    void Awake(){
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
