using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : MonoBehaviour
{
    public delegate void GetTriggert();
    public abstract event GetTriggert OnGettingTriggert;
}
