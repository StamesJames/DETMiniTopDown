using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHit : MonoBehaviour
{
    [SerializeField] LayerMask whatToHit;
    [SerializeField] PrefabPooler pooler;

    bool disable = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( (int) ( (1 << collision.gameObject.layer) & whatToHit) > 0)
        {
            disable = true;
        }
    }

    private void LateUpdate()
    {
        if (disable)
        {
            disable = false;
            pooler.PoolObject(this.gameObject);           
        }
    }
}
