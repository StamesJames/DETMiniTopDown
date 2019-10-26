using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RayCastEffect : ScriptableObject
{

    public abstract void TriggerEffect(RaycastHit2D hit);
}
