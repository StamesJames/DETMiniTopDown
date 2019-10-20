using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMasterAI : MonoBehaviour
{
    public delegate void OnTargetFound(GameObject target);
    public event OnTargetFound onTargetFound;

    GameObject currentTarget;

    public void SetTarget(GameObject target)
    {
        currentTarget = target;
        onTargetFound?.Invoke(currentTarget);
    }
}
