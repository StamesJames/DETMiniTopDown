using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class StatusEffect
{

    [SerializeField] protected string name;
    protected GameObject target;
    protected IStatusEffectable targetStatusEffectable;

    public string Name { get => name;}
}

public delegate void OnTick();
