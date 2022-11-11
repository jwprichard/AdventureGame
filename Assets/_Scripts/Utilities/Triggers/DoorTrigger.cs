using UnityEngine;
using Assets.Units;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] Room room;

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerUnit player = other.GetComponent<PlayerUnit>();
        if (player.currentRoom.name != room.name)
        {
            //Entering
            StartCoroutine(room.FadeTo(0, 0.5f));
            StartCoroutine(player.currentRoom.FadeTo(1, 0.5f));
            player.currentRoom = room;
        }

    }

}

