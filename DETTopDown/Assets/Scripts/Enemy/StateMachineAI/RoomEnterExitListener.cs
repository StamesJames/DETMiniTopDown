using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnterExitListener : MonoBehaviour
{
    [SerializeField] RoomEnterExitTrigger roomToListenTo;
    [SerializeField] int[] triggerIndexs;

    AIController aiController;

    private void Awake()
    {
        aiController = GetComponent<AIController>();
    }

    private void OnEnable()
    {
        roomToListenTo.onPlayerEnterRoom += OnPlayerEnters;
        roomToListenTo.onPlayerExitRoom += OnPlayerExits;
    }

    private void OnDisable()
    {
        roomToListenTo.onPlayerEnterRoom -= OnPlayerEnters;
        roomToListenTo.onPlayerExitRoom -= OnPlayerExits;
    }



    void OnPlayerEnters(GameObject player)
    {
        foreach (int triggerIndex in triggerIndexs)
        {
            aiController.SetTarget(player);
            aiController.Trigger(triggerIndex);
        }
    }

    void OnPlayerExits(GameObject player)
    {
        foreach (int triggerIndex in triggerIndexs)
        {
            aiController.SetTarget(player);
            aiController.Trigger(triggerIndex);
        }

    }
}
