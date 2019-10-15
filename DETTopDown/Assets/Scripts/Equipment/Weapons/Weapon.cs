using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, ITriggerable
{
    [SerializeField] string weaponName;
    public abstract void Trigger();
}
