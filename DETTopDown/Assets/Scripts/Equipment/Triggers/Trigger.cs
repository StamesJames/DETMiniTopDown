using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : MonoBehaviour
{
    private bool active;
    public bool Active { get => active; set => active = value; }

    public delegate void GetTriggert();
    public abstract event GetTriggert OnGettingTriggert;
}
