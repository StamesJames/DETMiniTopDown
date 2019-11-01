using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class StatusEffect
{

    [SerializeField] protected string name;
    protected GameObject target;
    protected IStatusEffectable targetStatusEffectable;
    [SerializeField]protected string[] blockedBy;

    public string Name { get => name;}


    public bool InteractWithOtherEffect(string otherName)
    {
        bool returnbool = true;
        foreach (string name in blockedBy)
        {
            if (otherName != null && otherName.Equals(name))
            {
                returnbool = false;
                destroyMe();
            }
        }

        return returnbool;
    }

    public abstract void RemoveEffect();

    void destroyMe()
    {
        RemoveEffect();
    }
}

public delegate void OnTick();
