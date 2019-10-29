using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIController : MonoBehaviour
{
    [SerializeField] Animator aiAnimController;
    [SerializeField] TriggerContainer[] triggers;

    Vector2 startPosition;
    GameObject currentTarget;
    public GameObject CurrentTarget { get => currentTarget; }

    public void Trigger(int index)
    {
        triggers[index]?.TriggerMe();
    }

    public void Trigger(string name)
    {
        foreach (TriggerContainer trigger in triggers)
        {
            if (trigger.Name.Equals(name))
            {
                trigger.TriggerMe();
            }
        }
    }

    public void SetTarget(GameObject target)
    {
        currentTarget = target;
        aiAnimController.SetBool("TARGET_FOUND", true);
    }

    public void RemoveTarget(GameObject target)
    {
        if (currentTarget.Equals(target))
        {
            currentTarget = null;
            aiAnimController.SetBool("TARGET_FOUND", false);
        }
    }

    public void RemoveTarget()
    {
        currentTarget = null;
        aiAnimController.SetBool("TARGET_FOUND", false);
    }


    [System.Serializable]
    class TriggerContainer
    {
        [SerializeField] string name;
        [SerializeField] ExternalTrigger trigger;

        public string Name { get => name; }

        public void TriggerMe()
        {
            trigger.TriggerMe();
        }
    }

}
