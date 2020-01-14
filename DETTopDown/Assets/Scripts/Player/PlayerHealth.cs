using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using EZCameraShake;

public class PlayerHealth : MonoBehaviour, IDamageable, IEffektGiveable
{
    public delegate void OnPlayerDeath(PlayerInformation information);

    public static event OnPlayerDeath onPlayerDeath;

    [SerializeField] Color startColor;
    [SerializeField] Color endColor;

    [SerializeField] float startHealth;
    [SerializeField] PrefabPooler damageEffect;
    [SerializeField] Image healthBar;
    [SerializeField] TextMeshProUGUI healthText;
    [Header("Sounds")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip hurtClip;
    [Header("Hurt CameraShake")]
    [SerializeField] float hurtShakeAmplitude;
    [SerializeField] float hurtShakeRoughness;
    [SerializeField] float hurtShakeFadeIn;
    [SerializeField] float hurtShakeFadeout;
    [SerializeField] GameObject gameOverScreeen;

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
        audioSource.PlayOneShot(hurtClip);

        CameraShaker.Instance.ShakeOnce(hurtShakeAmplitude, hurtShakeRoughness, hurtShakeFadeIn, hurtShakeFadeout);

        if(currentHealth <= 0){
            PlayerDath();
        }
    }

    void PlayerDath()
    {
        onPlayerDeath?.Invoke(new PlayerInformation { PlayerName = "Player_1" });
        gameOverScreeen.SetActive(true);
        Destroy(gameObject);
    }

    public PrefabPooler GetDamageEffect()
    {
        return damageEffect;
    }

    public void GetPushed(Vector2 direction, float force, float time)
    {

    }
}

public class PlayerInformation
{
    string playerName;

    public string PlayerName { get => playerName; set => playerName = value; }
}