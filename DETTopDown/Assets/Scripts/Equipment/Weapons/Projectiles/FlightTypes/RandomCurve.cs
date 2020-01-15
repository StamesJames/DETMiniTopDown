using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCurve : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float randomRange;

    float rotationRate;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        rotationRate = Random.Range(-randomRange, randomRange);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationRate * Time.deltaTime));
        rb.velocity = transform.right * rb.velocity.magnitude;
    }
}
