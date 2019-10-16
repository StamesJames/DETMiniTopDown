using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{

    [SerializeField] GraplingHook hookParent;
    Rigidbody2D rb;
    [SerializeField] float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            transform.SetParent(collision.transform);
            rb.velocity = Vector2.zero;
            hookParent.HookHit();
        }
    }
}
