using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnterExitListener : MonoBehaviour
{
    [SerializeField] RoomEnterExitTrigger roomToListenTo;
    [SerializeField] int[] triggerIndexs;

    AIController aiController;

    public RoomEnterExitTrigger RoomToListenTo { get => roomToListenTo;
        set {
            if (roomToListenTo != null)
            {
                roomToListenTo.onPlayerEnterRoom -= OnPlayerEnters;
                roomToListenTo.onPlayerExitRoom -= OnPlayerExits;
            }
            roomToListenTo = value;
            roomToListenTo.onPlayerEnterRoom += OnPlayerEnters;
            roomToListenTo.onPlayerExitRoom += OnPlayerExits;
        }
    }

    private void Awake()
    {
        aiController = GetComponent<AIController>();
    }

    private void OnEnable()
    {
        if (roomToListenTo)
        {
            roomToListenTo.onPlayerEnterRoom += OnPlayerEnters;
            roomToListenTo.onPlayerExitRoom += OnPlayerExits;
        }
    }

    private void OnDisable()
    {
        if (roomToListenTo)
        {
            roomToListenTo.onPlayerEnterRoom -= OnPlayerEnters;
            roomToListenTo.onPlayerExitRoom -= OnPlayerExits;
        }
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
