using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour, IDamageable, IEffektGiveable
{
    [SerializeField] PrefabPooler particlePool;
    [SerializeField] float startHealth;
    [Header("Unity Stuff")]
    [SerializeField] Image healthBar;
    float lifetotal;

    Rigidbody2D rb;


    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
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

    public void GetPushed(Vector2 direction, float force)
    {
        rb.AddForce(direction.normalized * force);
    }
}
