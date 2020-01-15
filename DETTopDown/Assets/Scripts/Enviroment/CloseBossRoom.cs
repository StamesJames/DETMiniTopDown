using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseBossRoom : MonoBehaviour
{
    [SerializeField] RoomEnterExitTrigger trigger;
    [SerializeField] GameObject closingDoor;
    [SerializeField] GameObject bossLifeBar;

    private void OnEnable()
    {
        trigger.onPlayerEnterRoom += OnEnter;
    }

    private void OnDisable()
    {
        trigger.onPlayerEnterRoom -= OnEnter;
    }

    void OnEnter(GameObject player)
    {
        closingDoor.SetActive(true);
        bossLifeBar.SetActive(true);
    }

}
