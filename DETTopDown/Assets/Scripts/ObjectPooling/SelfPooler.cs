using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfPooler : MonoBehaviour
{

    [SerializeField] PrefabPooler projectilePool;
    public void PoolMe()
    {
        projectilePool.PoolObject(this.gameObject);
    }
}
