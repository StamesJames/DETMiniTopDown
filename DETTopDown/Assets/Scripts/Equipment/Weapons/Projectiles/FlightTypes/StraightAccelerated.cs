using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightAccelerated : MonoBehaviour
{
    [SerializeField] float accelerationForce;
    [SerializeField] float maxSpeed = float.PositiveInfinity;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(transform.right * accelerationForce * Time.deltaTime);
        }
    }
}
