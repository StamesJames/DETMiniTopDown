using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingPlasmaCanon : MonoBehaviour
{
    [SerializeField] PrefabPooler projectile;
    [SerializeField] float maxDamage;
    [SerializeField] Transform shotSpawn;
    [SerializeField] float loadingTime;
    [SerializeField] float unloadTime;
    [SerializeField] string buttonToPress = "Fire2";
    [SerializeField] float speed;
 
    float currentLoad;
    float loadRate;
    float unloadRate;

    bool loading;
    Animator currentProjectileAnim;

    GameObject curentProjectile;

    void Awake(){
                if (loadingTime > 0 )
        {
            loadRate = 1 / loadingTime;
        }
        else
        {
            loadRate = 0;
        }

        if (unloadTime > 0)
        {
            unloadTime = 1 / loadingTime;
        }
        else
        {
            unloadRate = float.PositiveInfinity;
        }
    }

    void Update(){
        if(Input.GetButtonDown(buttonToPress)){
            curentProjectile = projectile.GetObject(shotSpawn, shotSpawn);
            currentProjectileAnim = curentProjectile.GetComponent<Animator>();
        }

        if(Input.GetButton(buttonToPress) && curentProjectile != null){
            currentLoad = Mathf.Clamp01(currentLoad + loadRate * Time.deltaTime);
            currentProjectileAnim.SetFloat("LOAD", currentLoad);
            curentProjectile.transform.position = shotSpawn.position;
            curentProjectile.transform.rotation = shotSpawn.rotation;
            loading = true;
        }

        if(Input.GetButtonUp(buttonToPress)){
            Shoot();
            curentProjectile = null;
        }
    }

    void Shoot(){
        curentProjectile.GetComponent<StraightLinear>().fireMe(speed);
        curentProjectile.GetComponent<SingleDamageInflictor>().Damage = currentLoad * maxDamage;
        curentProjectile.transform.SetParent(null);
        currentLoad = 0;
    }

} 
