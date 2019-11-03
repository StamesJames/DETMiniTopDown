using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimToTargetSmart : MonoBehaviour
{

    [SerializeField] float projectileSpeed;

    AIController aiController;

    Vector2 aimSpot;

    Rigidbody2D targetRb;



    void Awake(){
        aiController = GetComponentInParent<AIController>();
    }

    // Update is called once per frame
    void Update()
    {
     
        if (aiController.CurrentTarget)
        {
            targetRb = aiController.CurrentTarget.GetComponent<Rigidbody2D>();
            aimSpot = (Vector2)targetRb.transform.position + targetRb.velocity * ((aiController.CurrentTarget.transform.position - transform.position).magnitude / projectileSpeed);
            AimWeapon.Instance.Aim(transform, aimSpot);            
        }        
    }
}
