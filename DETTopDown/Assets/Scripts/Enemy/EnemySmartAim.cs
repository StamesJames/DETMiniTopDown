using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmartAim : MonoBehaviour
{
    [SerializeField] Transform[] whatToAims;
    [SerializeField] PrefabPooler whatGetsShot;

    GameObject currentTarget;
    Rigidbody2D targetRb;
    FlightType projectile;
    Vector2 aimSpot;
    float projectileSpeed;
    EnemyMasterAI masterAI;

    private void Awake()
    {
        projectile = whatGetsShot.GetPrefab().GetComponent<FlightType>();
        projectileSpeed = projectile.Speed;
        masterAI = GetComponent<EnemyMasterAI>();
    }

    private void OnEnable()
    {
        masterAI.onTargetFound += OnTargetFound;
    }

    private void OnDisable()
    {
        masterAI.onTargetFound -= OnTargetFound;    
    }

    void OnTargetFound(GameObject target)
    {
        currentTarget = target;
        if (target)
        {
            targetRb = target.GetComponent<Rigidbody2D>();
        }
    }

    private void Update()
    {
        if (currentTarget)
        {
            aimSpot = (Vector2)targetRb.transform.position + targetRb.velocity * ((currentTarget.transform.position - transform.position).magnitude / projectileSpeed);

            foreach (Transform whatToAim in whatToAims)
            {
                AimWeapon.Instance.Aim(whatToAim.transform, aimSpot);
            }

        }
    }

}
