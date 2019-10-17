using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, ITriggerable
{
    [SerializeField] string weaponName = "!!!UNNAMED!!!";
    public abstract void Trigger();
}
