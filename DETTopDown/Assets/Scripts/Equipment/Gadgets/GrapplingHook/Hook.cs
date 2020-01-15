using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{

    [SerializeField] GraplingHook hookParent;
    [SerializeField] LayerMask whatToHit;
    Rigidbody2D rb;

    float speed = 30f;

    public float Speed { get => speed; set => speed = value; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        rb.velocity = transform.right * Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( ( (1 << collision.gameObject.layer) & whatToHit ) > 0 )
        {
            transform.SetParent(collision.transform);
            rb.velocity = Vector2.zero;
            hookParent.HookHit();
        }
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rb.velocity.normalized, rb.velocity.magnitude / 10, whatToHit);
        if (hit)
        {
            transform.position = hit.point;
            transform.SetParent(hit.transform);
            rb.velocity = Vector2.zero;
            hookParent.HookHit();
        }
    }

}
