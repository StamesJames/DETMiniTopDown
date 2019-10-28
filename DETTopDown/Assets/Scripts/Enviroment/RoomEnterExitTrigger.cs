using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnterExitTrigger : MonoBehaviour
{

    public delegate void OnPlayerEnterRoom(GameObject player);

    public event OnPlayerEnterRoom onPlayerEnterRoom;
    public event OnPlayerEnterRoom onPlayerExitRoom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            onPlayerEnterRoom?.Invoke(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            onPlayerExitRoom?.Invoke(collision.gameObject);
        }
    }
}
