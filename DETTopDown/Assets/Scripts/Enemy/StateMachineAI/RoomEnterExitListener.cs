using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnterExitListener : MonoBehaviour
{
    [SerializeField] RoomEnterExitTrigger roomToListenTo;
    [SerializeField] int triggerIndex;

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
        aiController.SetTarget(player);
        aiController.Trigger(triggerIndex);
    }

    void OnPlayerExits(GameObject player)
    {
        aiController.RemoveTarget(player);
        aiController.Trigger(triggerIndex);

    }
}
