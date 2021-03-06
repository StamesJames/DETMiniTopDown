﻿using System.Collections;
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
        origin = new GameObject().transform;
        origin.position = transform.position;
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
            if (lineHit && lineHit.collider.gameObject.Equals( aiController.CurrentTarget.gameObject) )
            {
                path.endReachedDistance = stopDistance;
                path.slowdownDistance = stopDistance + 1;
            }
            else
            {
                path.endReachedDistance = 0.3f;
                path.slowdownDistance = 0.3f + 1;
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
        stateTrigger?.Invoke();
    }
}
