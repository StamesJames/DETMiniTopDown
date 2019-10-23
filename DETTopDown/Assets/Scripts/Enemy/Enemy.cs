using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class Enemy : MonoBehaviour, IDamageable, IEffektGiveable, IStatusEffectable
{
    [SerializeField] PrefabPooler particlePool;
    [SerializeField] float startHealth;
    [Header("UI Stuff")]
    [SerializeField] Image healthBar;
    float lifetotal;

    Rigidbody2D rb;

    // Status Effect Kram
    List<StatusEffect> statusEffects = new List<StatusEffect>();
    event OnTick onTickEvent;

    // Pathfinding Kram
    Seeker seeker;
    AIPath path;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();
        path = GetComponent<AIPath>();
    }

    private void OnEnable()
    {
        lifetotal = startHealth;
        healthBar.fillAmount = lifetotal/startHealth;       
    }

    private void Update()
    {
        onTickEvent?.Invoke();
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

    public void GetPushed(Vector2 direction, float force, float time)
    {
        seeker.enabled = false;
        path.enabled = false;
        rb.AddForce(direction.normalized * force);

        Invoke("StopGettingPushed", time);
    }

    private void OnDisable()
    {
        CancelInvoke();
        onTickEvent = null;
    }

    void StopGettingPushed()
    {
        seeker.enabled = true;
        path.enabled = true;
    }

    public IDamageable GetIDamageable()
    {
        return this;
    }

    public void AddStatusEffect(StatusEffect effect)
    {
        statusEffects.Add(effect);
    }

    public void RemoveStatusEffect(StatusEffect effect)
    {
        statusEffects.Remove(effect);
    }

    public void AddOnTick(OnTick onTick)
    {
        onTickEvent += onTick;
    }

    public void RemoveOnTick(OnTick onTick)
    {
        onTickEvent -= onTick;
    }
}
