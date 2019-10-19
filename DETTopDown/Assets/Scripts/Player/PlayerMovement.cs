using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;

    float vertical;
    float horizontal;
    bool inputActive = true;
    Rigidbody2D rb;
    Vector2 inputVec;

    public bool InputActive { get => inputActive; set => inputActive = value; }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InputActive)
        {
            vertical = UnityEngine.Input.GetAxis("Vertical");
            horizontal = UnityEngine.Input.GetAxis("Horizontal");
            inputVec = new Vector2(horizontal, vertical);
        }
    }

    //FixedUpdate is called once every 0,02 s
    private void FixedUpdate()
    {
        if (InputActive)
        {
            inputVec = Vector2.ClampMagnitude(inputVec, 1);
            rb.velocity = (inputVec * speed);
        }
        //normalized setzt vector auf länge 1 , verhindern von schrägen speed höher
        //Time.deltaTime ist die Zeit zwischen dem letzten FixedUpdate aufruf und jetzt 
    }

    public void MovePlayer(Vector2 moveVec, float speed)
    {
        rb.velocity = (moveVec.normalized * speed);
    }
}
