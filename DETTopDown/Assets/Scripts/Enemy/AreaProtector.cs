using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


[RequireComponent(typeof(Seeker), typeof(AIDestinationSetter), typeof(AIPath))]
public class AreaProtector : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float protectionRadius = 10f;
    [SerializeField] float followRadius = 20f;
    [SerializeField] float stopDistance;
    [SerializeField] LayerMask whatToAttack;
    [SerializeField] LayerMask whatIsObstacle;

    AttackAI attackAI;
    Transform origin;
    Collider2D targetHit;
    AIPath path;
    Seeker seeker;
    AIDestinationSetter destSetter;
    bool onTheWay = false;

    private void OnDrawGizmosSelected()
    {
        if (origin == null)
        {
            Gizmos.color = new Color(1, 1, 0);
            Gizmos.DrawWireSphere(transform.position, protectionRadius);
            Gizmos.color = new Color(1, 0, 1);
            Gizmos.DrawWireSphere(transform.position, followRadius);
        }
        else
        {
            Gizmos.color = new Color(1, 1, 0);
            Gizmos.DrawWireSphere(origin.position, protectionRadius);
            Gizmos.color = new Color(1, 0, 1);
            Gizmos.DrawWireSphere(origin.position, followRadius);
        }
    }

    private void Awake()
    {
        GameObject emptyGameObject = new GameObject();
        seeker = GetComponent<Seeker>();
        destSetter = GetComponent<AIDestinationSetter>();
        attackAI = GetComponent<AttackAI>();
        path = GetComponent<AIPath>();
        origin = Instantiate(emptyGameObject, transform.position, transform.rotation).transform;
        destSetter.target = origin;
    }

    // Update is called once per frame
    void Update()
    {
        if (!onTheWay)
        {
            targetHit = Physics2D.OverlapCircle(origin.position, protectionRadius, whatToAttack);
            if (targetHit != null)
            {
                onTheWay = true;
                destSetter.target = targetHit.transform;
                path.endReachedDistance = stopDistance;
                attackAI.SetTarget(targetHit.gameObject);
            }
        }
        else if (targetHit)
        {
            Vector3 connectionVec = (targetHit.transform.position - transform.position).normalized;
            RaycastHit2D lineHit =  Physics2D.Linecast(this.transform.position + connectionVec, targetHit.transform.position + connectionVec, whatIsObstacle);
            Debug.Log(lineHit.collider.gameObject.name + " is in the way");
            if (lineHit.collider.gameObject == targetHit.gameObject)
            {
                path.endReachedDistance = stopDistance;
            }
            else
            {
                path.endReachedDistance = 0.3f;
            }         
            if ((origin.position - targetHit.transform.position).magnitude > followRadius)
            {
                destSetter.target = origin.transform;
                onTheWay = false;
                path.endReachedDistance = 0.3f;
                attackAI.SetTarget(null);       
            }
        }

    }
}
