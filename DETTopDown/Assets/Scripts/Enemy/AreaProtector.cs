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

    delegate void AreaProtectorAction();

    AreaProtectorAction state;

    Transform origin;
    Collider2D targetHit;
    AIPath path;
    Seeker seeker;
    AIDestinationSetter destSetter;
    bool onTheWay = false;
    EnemyMasterAI masterAI;

    #region Gizmos
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
    #endregion

    private void Awake()
    {
        GameObject emptyGameObject = new GameObject();
        seeker = GetComponent<Seeker>();
        destSetter = GetComponent<AIDestinationSetter>();
        path = GetComponent<AIPath>();
        origin = Instantiate(emptyGameObject, transform.position, transform.rotation).transform;
        destSetter.target = origin;
        masterAI = GetComponent<EnemyMasterAI>();
        state = Waiting;
    }

    // Update is called once per frame
    void Update()
    {
        state?.Invoke();
    }

    void Chasing()
    {
        //Debug.Log("Chasing " + targetHit.gameObject.name);
        if (targetHit)
        {
            destSetter.target = targetHit.transform;
            Vector3 connectionVec = (targetHit.transform.position - transform.position).normalized;
            RaycastHit2D lineHit = Physics2D.Linecast(this.transform.position, targetHit.transform.position + connectionVec, whatIsObstacle);
            //Debug.Log(lineHit.collider.gameObject.name + "in The Way");
            if (lineHit && lineHit.collider.gameObject == targetHit.gameObject)
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

            if ((origin.position - targetHit.transform.position).magnitude > followRadius)
            {
                destSetter.target = origin.transform;
                path.endReachedDistance = 0.3f;
                path.slowdownDistance = 0.3f + 3;
                state = Returning;
            }
        }

    }

    void Waiting()
    {
        targetHit = Physics2D.OverlapCircle(origin.position, protectionRadius, whatToAttack);
        if (targetHit != null)
        {
            state = Chasing;
            masterAI.SetTarget(targetHit.gameObject);
            destSetter.target = targetHit.transform;
            path.endReachedDistance = stopDistance;
        }
    }

    void Returning()
    {
        if ( (transform.position - origin.position).magnitude < 0.5f )
        {
            masterAI.SetTarget(null);
            state = Waiting;
            return;
        }

        targetHit = Physics2D.OverlapCircle(origin.position, protectionRadius, whatToAttack);
        if (targetHit != null)
        {
            masterAI.SetTarget(targetHit.gameObject);
            destSetter.target = targetHit.transform;
            path.endReachedDistance = stopDistance;
            state = Chasing;
        }
    }

}
