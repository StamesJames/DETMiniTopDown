using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesTime : MonoBehaviour
{
    [SerializeField] float inaktiveTime;
    [SerializeField] float aktiveTime;
    [SerializeField] float damage;
    [SerializeField] DAMAGETYPE damageType;
    [SerializeField] float timeBetweenDamages;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite aktiveSprite;
    [SerializeField] Sprite inaktiveSprite;

    bool aktive = false;

    float nextTrigger;
    float nextDamage;


    private void Update()
    {
        if (nextTrigger <= 0)
        {
            Trigger();
        }
        else if (nextTrigger > 0)
        {
            nextTrigger -= Time.deltaTime;
        }

        if (nextDamage > 0 && aktive)
        {
            nextDamage -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (aktive)
        {
            IDamageable target = collision.gameObject.GetComponent<IDamageable>();
            if (target != null)
            {
                target.GetDamaged(damage, damageType);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (nextDamage <= 0)
        {
            IDamageable target = collision.gameObject.GetComponent<IDamageable>();
            if (target != null)
            {
                target.GetDamaged(damage, damageType);
            }
            nextDamage = timeBetweenDamages;
        }
    }

    void Trigger()
    {
        aktive = !aktive;

        if (aktive)
        {
            spriteRenderer.sprite = aktiveSprite;
            nextDamage = timeBetweenDamages;
            nextTrigger = aktiveTime;
        }
        else
        {
            spriteRenderer.sprite = inaktiveSprite;
            nextDamage = timeBetweenDamages;
            nextTrigger = inaktiveTime;
        }

    }
}
