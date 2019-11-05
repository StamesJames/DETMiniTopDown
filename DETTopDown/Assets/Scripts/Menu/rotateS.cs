using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateS : MonoBehaviour
{
    public float rotationRate = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("You spin me right round baby");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.back, rotationRate * Time.deltaTime);
    }
}
