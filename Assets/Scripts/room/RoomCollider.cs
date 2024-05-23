using UnityEngine;

public class RoomCollider : MonoBehaviour
{
    public int roomIndex;
    private RoomManager roomManager;

    void Start()
    {
        roomManager = FindObjectOfType<RoomManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            roomManager.SwitchToRoom(roomIndex);
        }
    }
}