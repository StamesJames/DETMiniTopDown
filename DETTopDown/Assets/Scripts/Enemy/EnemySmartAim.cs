using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmartAim : MonoBehaviour
{
    [SerializeField] Transform whatToAim;
    [SerializeField] PrefabPooler whatGetsShot;

    GameObject currentTarget;
    Rigidbody2D targetRb;
    FlightType projectile;
    Vector2 aimSpot;
    float projectileSpeed;

    private void Awake()
    {
        projectile = whatGetsShot.GetPrefab().GetComponent<FlightType>();
        projectileSpeed = projectile.Speed;
    }

    public void SetTarget(GameObject target)
    {
        currentTarget = target;
        if (target)
            targetRb = target.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (currentTarget)
        {
            aimSpot = (Vector2)targetRb.transform.position + targetRb.velocity * ((currentTarget.transform.position - transform.position).magnitude / projectileSpeed);
            Vector2 lookVec = aimSpot - (Vector2)transform.position;
            float lookAngle = Mathf.Atan2(lookVec.y, lookVec.x) * Mathf.Rad2Deg;
            whatToAim.rotation = Quaternion.Euler(new Vector3(0, 0, lookAngle));
        }
    }

}
