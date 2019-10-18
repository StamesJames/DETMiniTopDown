using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SelfPooler))]
public class DestroyOnHit : MonoBehaviour
{
    [SerializeField] LayerMask whatToHit;

    SelfPooler pooler;

    // Start is called before the first frame update
    void Awake()
    {
        pooler = GetComponent<SelfPooler>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log( "Verundung: " + ((collision.gameObject.layer & whatToHit) > 0 ));
        if ( (int) ( (1 << collision.gameObject.layer) & whatToHit) > 0)
        {
            pooler.PoolMe();
        }
    }
}
