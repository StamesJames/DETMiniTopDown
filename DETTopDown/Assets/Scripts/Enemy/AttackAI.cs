using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackAI : MonoBehaviour
{
    protected GameObject currentTarget;
    public abstract void SetTarget(GameObject target);
}
