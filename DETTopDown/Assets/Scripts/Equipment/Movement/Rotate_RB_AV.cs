using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_RB_AV : MonoBehaviour
{
    [SerializeField] float angularSpeed;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        rb.angularVelocity = angularSpeed;

    }
}
