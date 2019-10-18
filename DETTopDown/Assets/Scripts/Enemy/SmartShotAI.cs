using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartShotAI : AttackAI
{
    [SerializeField] PrefabPooler projectilePool;
    [SerializeField] Transform weapon;
    [SerializeField] float shotRate;
    [SerializeField] Transform shotSpawn;

    Rigidbody2D targetRB;
    StraightLinear projectile;
    Vector2 aimSpot;
    float projectileSpeed;
    float shotCD;
    float nextShot = 0;

    private void Awake()
    {
        if (shotRate > 0)
        {
            shotCD = 1 / shotRate;
        }
        else
        {
            shotCD = float.PositiveInfinity;
        }
        projectile = projectilePool.GetPrefab().GetComponent<StraightLinear>();
        projectileSpeed = projectile.Speed;
    }

    public override void SetTarget(GameObject target)
    {
        currentTarget = target;
        if(target)
            targetRB = target.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (currentTarget)
        {
            aimSpot = (Vector2) targetRB.transform.position + targetRB.velocity * ( (currentTarget.transform.position - transform.position).magnitude / projectileSpeed);
            Vector2 lookVec = aimSpot - (Vector2) transform.position;
            float lookAngle = Mathf.Atan2(lookVec.y, lookVec.x) * Mathf.Rad2Deg;
            weapon.rotation = Quaternion.Euler(new Vector3(0, 0, lookAngle));
            if (nextShot <= 0)
            {
                projectilePool.GetObject(shotSpawn);
                nextShot = shotCD;
            }
            else if (nextShot > 0)
            {
                nextShot -= Time.deltaTime;
            }

        }
    }

}
