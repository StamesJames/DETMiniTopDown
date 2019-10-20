using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMasterAI : MonoBehaviour
{
    public delegate void TargetFound(GameObject target);
    public event TargetFound targetFound;

    GameObject currentTarget;

    public void SetTarget(GameObject target)
    {
        currentTarget = target;
        targetFound?.Invoke(currentTarget);
    }
}
