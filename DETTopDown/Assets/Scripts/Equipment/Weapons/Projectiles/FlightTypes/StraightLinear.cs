using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StraightLinear : FlightType
{

    Rigidbody2D rb;
    [SerializeField] bool randomize = false;
    [SerializeField] float randomRange = 2f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        rb.velocity = transform.right * (Speed + (randomize ? Random.Range(-randomRange, randomRange) : 0 ));
    }

}
