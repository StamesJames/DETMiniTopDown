using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedLifetime : MonoBehaviour
{
    [SerializeField] PrefabPooler pool;
    [SerializeField] float lifeTime;

    private void OnEnable()
    {
        Invoke("PoolMe", lifeTime);
    }

    void PoolMe()
    {
        pool.PoolObject(this.gameObject);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
