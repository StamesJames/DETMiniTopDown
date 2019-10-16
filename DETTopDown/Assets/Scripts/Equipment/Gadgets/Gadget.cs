using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gadget : MonoBehaviour, ITriggerable
{
    public abstract void Trigger();

}
