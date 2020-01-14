using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnterExitTrigger : MonoBehaviour
{

    public delegate void OnPlayerEnterRoom(GameObject player);

    public event OnPlayerEnterRoom onPlayerEnterRoom;
    public event OnPlayerEnterRoom onPlayerExitRoom;

    bool playerIsInRoom = false;

    public bool PlayerIsInRoom { get => playerIsInRoom; set => playerIsInRoom = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            playerIsInRoom = true;
            onPlayerEnterRoom?.Invoke(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            playerIsInRoom = false;
            onPlayerExitRoom?.Invoke(collision.gameObject);
        }
    }
}
