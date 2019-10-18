using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SelfPooler))]
public class DestroyOverTime : MonoBehaviour
{
    [SerializeField] float lifeTime;

    SelfPooler pooler;

    private void Awake()
    {
        pooler = GetComponent<SelfPooler>();
    }

    private void OnEnable()
    {
        Invoke("PoolMe", lifeTime);
    }

    void PoolMe()
    {
        pooler.PoolMe();
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
