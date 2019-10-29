using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfPooler : MonoBehaviour
{

    [SerializeField] PrefabPooler projectilePool;
    bool poolIt;

    private void OnEnable()
    {
        poolIt = false;
    }

    public void PoolMe()
    {
        poolIt = true;
    }

    private void LateUpdate()
    {
        if (poolIt)
        {
            projectilePool.PoolObject(this.gameObject);
        }
    }

}
