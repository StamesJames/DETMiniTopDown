using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterXBounces : MonoBehaviour
{
    [SerializeField] int maxCollisions;
    [SerializeField] LayerMask whatToHit;

    int currnetCollisions;
    SelfPooler pooler;

    private void Awake()
    {
        pooler = GetComponent<SelfPooler>();
    }

    private void OnEnable()
    {
        currnetCollisions = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & whatToHit) > 0)
        {
            currnetCollisions++;
            if (currnetCollisions >= maxCollisions)
            {
                pooler.PoolMe();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & whatToHit) > 0)
        {
            currnetCollisions++;
            if (currnetCollisions >= maxCollisions)
            {
                pooler.PoolMe();
            }
        }
    }
}
