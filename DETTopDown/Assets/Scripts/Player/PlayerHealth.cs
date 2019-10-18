using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour, IDamageable, IEffektGiveable
{
    [SerializeField] Color startColor;
    [SerializeField] Color endColor;

    [SerializeField] float startHealth;
    [SerializeField] PrefabPooler damageEffect;
    [SerializeField] Image healthBar;
    [SerializeField] TextMeshProUGUI healthText;
    float currentHealth;


    void Awake(){
        currentHealth = startHealth;
        healthText.SetText(currentHealth.ToString());
        healthBar.fillAmount = currentHealth / startHealth;
        healthBar.color = Color.Lerp(endColor, startColor, currentHealth / startHealth);
    }

    public void GetDamaged(float dmg, DAMAGETYPE type)
    {
        currentHealth -= dmg;
        healthText.SetText(currentHealth.ToString());
        healthBar.fillAmount = currentHealth / startHealth;
        healthBar.color = Color.Lerp(endColor, startColor, currentHealth / startHealth);


        if(currentHealth <= 0){
            Destroy(gameObject);
        }
    }

    public PrefabPooler GetDamageEffect()
    {
        return damageEffect;
    }

}
