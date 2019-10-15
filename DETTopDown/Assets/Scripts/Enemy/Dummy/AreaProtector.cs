using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AreaProtector : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float nextWaypointDistance = 3f;
    [SerializeField] float protectionRadius = 10f;
    [SerializeField] float followRadius = 20f;
    [SerializeField] LayerMask whatToAttack;

    AttackAI attackAI;
    Transform origin;
    Collider2D targetHit;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

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
        origin = Instantiate(emptyGameObject, transform.position, transform.rotation).transform;
        destSetter.target = origin;
    }

    // Update is called once per frame
    void Update()
    {
        if (!onTheWay)
        {
            targetHit = Physics2D.OverlapCircle(origin.position, protectionRadius, whatToAttack);
            Debug.Log("Scaning for target");
            if (targetHit != null)
            {
                Debug.Log("gefunden: " + targetHit.name);
                onTheWay = true;
                destSetter.target = targetHit.transform;
                attackAI.SetTarget(targetHit.gameObject);
            }
        }
        else if (targetHit)
        {
            if ((origin.position - targetHit.transform.position).magnitude > followRadius)
            {
                destSetter.target = origin.transform;
                onTheWay = false;               
            }
        }

    }
}
