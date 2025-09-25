using UnityEngine;

public class RoonManager : MonoBehaviour
{
    public RoomController[] rooms;
    private RoomController currentRoom;

    private void Update()
    {
        foreach (RoomController room in rooms)
        {
            room.TickRoom(Time.deltaTime);
        }
    }

    public void SwitchRoom(string roomName)
    {
        foreach (RoomController room in rooms)
        {
            room.isCurrentRoom = false;
            room.gameObject.SetActive(false);
        }

        currentRoom = System.Array.Find(rooms, r => r.roomName == roomName);

        if (currentRoom != null )
        {
            currentRoom.isCurrentRoom = true;
            currentRoom.gameObject.SetActive(true);
        }
    }
}
