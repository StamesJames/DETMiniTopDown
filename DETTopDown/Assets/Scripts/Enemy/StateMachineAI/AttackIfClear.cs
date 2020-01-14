using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackIfClear : TriggerEffect
{
    [SerializeField] string[] triggerNames;
    [SerializeField] float timeBetweenShots;
    [SerializeField] LayerMask whatIsObstacle;
    [SerializeField] float randomRange = 0;
    bool active = false;

    AIController aiController;
    Transform currentTarget;

    void Awake(){
        aiController = GetComponentInParent<AIController>();
    }

    float nextShotIn;

    void Update(){
        //RaycastHit2D lineHit = Physics2D.Linecast(aiController.transform, )
        if(active && nextShotIn <= 0){
            Vector3 connectionVec = aiController.CurrentTarget.transform.position - transform.position;
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, 0.3f, connectionVec.normalized, connectionVec.magnitude, whatIsObstacle);
            if (hit && hit.collider.gameObject.Equals(aiController.CurrentTarget))
            {
                foreach (string triggerName in triggerNames)
                {
                    aiController.Trigger(triggerName);
                }
                nextShotIn = timeBetweenShots + Random.Range(-randomRange, randomRange);
            }
        }else if (nextShotIn > 0){
            nextShotIn -= Time.deltaTime;
        }
    }

    protected override void Trigger()
    {
        active = !active;
    }
}
