using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ChasingPlayer : TriggerEffect
{
    [SerializeField] float speed = 10f;
    [SerializeField] float stopDistance = 5f;
    [SerializeField] LayerMask whatIsObstacle;

    delegate void ChasingPlayerAction();

    
    ChasingPlayerAction stateUpdate;
    ChasingPlayerAction stateTrigger;

    Transform origin;


    [SerializeField] AIController aiController;
    [SerializeField] AIPath path;
    [SerializeField] Seeker seeker;
    [SerializeField] AIDestinationSetter destSetter;
    bool onTheWay = false;

    private void Awake()
    {
        GameObject emptyGameObject = new GameObject();
        origin = Instantiate(emptyGameObject, transform.position, transform.rotation).transform;
        destSetter.target = origin;
        stateUpdate = WaitingUpdate;
        stateTrigger = WaitingTrigger;
    }

    // Update is called once per frame
    void Update()
    {
        stateUpdate?.Invoke();
    }

    void ChasingTrigger()
    {
        stateUpdate = ReturningUpdate;
        stateTrigger = ReturningTrigger;

        destSetter.target = origin;

        path.endReachedDistance = 0.3f;
        path.slowdownDistance = 0.3f + 3;
    }

    void ChasingUpdate()
    {
            Vector3 connectionVec = aiController.CurrentTarget.transform.position - transform.position;
            RaycastHit2D lineHit = Physics2D.CircleCast(transform.position, 0.3f, connectionVec.normalized, connectionVec.magnitude, whatIsObstacle);
            Debug.Log("Found " + lineHit.collider.gameObject.name + " in the way");
            if (lineHit && lineHit.collider.gameObject == aiController.CurrentTarget.gameObject)
            {
                path.endReachedDistance = stopDistance;
                path.slowdownDistance = stopDistance + 3;
            }
            else
            {
                path.endReachedDistance = 0.3f;
                path.slowdownDistance = 0.3f + 3;

                path.SearchPath();
            }
    }

    void WaitingTrigger()
    {
        stateUpdate = ChasingUpdate;
        stateTrigger = ChasingTrigger;
        destSetter.target = aiController.CurrentTarget.transform;
        path.SearchPath();
        path.endReachedDistance = stopDistance;
    }

    void WaitingUpdate()
    {

    }

    void ReturningTrigger()
    {
        stateUpdate = ChasingUpdate;
        stateTrigger = ChasingTrigger;
        destSetter.target = aiController.CurrentTarget.transform;
        path.endReachedDistance = stopDistance;
    }

    void ReturningUpdate()
    {

    }

    protected override void Trigger()
    {
        Debug.Log("Got Triggert");
        stateTrigger?.Invoke();
    }
}
