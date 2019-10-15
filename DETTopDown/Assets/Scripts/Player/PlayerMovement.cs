using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    float vertical;
    float horizontal;
    [SerializeField] float speed;

    Vector2 inputVec;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        inputVec = new Vector2(horizontal, vertical);
    }

    //FixedUpdate is called once every 0,02 s
    private void FixedUpdate()
    {      
        inputVec = Vector2.ClampMagnitude(inputVec, 1);

        rb.velocity = (inputVec * speed);
        //normalized setzt vector auf länge 1 , verhindern von schrägen speed höher
        //Time.deltaTime ist die Zeit zwischen dem letzten FixedUpdate aufruf und jetzt 
    }
}
