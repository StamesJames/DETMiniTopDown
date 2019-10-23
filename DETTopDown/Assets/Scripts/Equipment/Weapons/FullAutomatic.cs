using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullAutomatic : Weapon
{
    [SerializeField] float feuerrate;
    [SerializeField] Transform[] shotSpawns;
    [SerializeField] PrefabPooler projectile;

    float shotCd;
    float nextShot = 0;
    public override void Trigger()
    {   
        foreach (Transform shotSpawn in shotSpawns)
        {
            projectile.GetObject(shotSpawn);
        }
    }

    void OnValidate(){
        if(feuerrate<=0){
            shotCd = float.PositiveInfinity;
        }else{
            shotCd = 60/feuerrate;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(feuerrate<=0){
            shotCd = float.PositiveInfinity;
        }else{
            shotCd = 60/feuerrate;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1")&&nextShot<=0){
            nextShot = shotCd;
            Trigger();
        }else if(nextShot>0){
            nextShot -= Time.deltaTime;
        }
    }
}
