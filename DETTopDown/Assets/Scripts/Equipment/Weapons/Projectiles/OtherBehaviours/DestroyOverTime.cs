using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    [SerializeField] float lifeTime;
    [SerializeField] PrefabPooler pooler;

    bool poolMe = false;

    private void OnEnable()
    {
        Invoke("PoolMe", lifeTime);
    }

    void PoolMe()
    {
        poolMe = true; 
    }

    private void LateUpdate()
    {
        if (poolMe)
        {
            poolMe = false;
            pooler.PoolObject(this.gameObject);
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
