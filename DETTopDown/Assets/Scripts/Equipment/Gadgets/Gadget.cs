using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gadget : MonoBehaviour, ITriggerable
{
    [SerializeField] string gadgetName = "!!!UNAMED!!!";
    public abstract void Trigger();

}
