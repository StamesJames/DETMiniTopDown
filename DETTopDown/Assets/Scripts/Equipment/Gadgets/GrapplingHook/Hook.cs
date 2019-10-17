using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{

    [SerializeField] GraplingHook hookParent;

    float speed = 30f;
    Rigidbody2D rb;

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
        Debug.Log("Collided with: " + collision.gameObject.name);

        if (!collision.CompareTag("Player"))
        {
            transform.SetParent(collision.transform);
            rb.velocity = Vector2.zero;
            hookParent.HookHit();
        }
    }
}
