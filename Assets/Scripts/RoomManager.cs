using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject[] rooms;
    private int currentRoomIndex = 0;

    void Start()
    {
        // 처음에 첫 번째 방만 활성화하고 나머지 방은 비활성화
        for (int i = 0; i < rooms.Length; i++)
        {
            if (i == currentRoomIndex)
            {
                rooms[i].SetActive(true);
            }
            else
            {
                rooms[i].SetActive(false);
            }
        }
    }

    public void SwitchToRoom(int roomIndex)
    {
        if (roomIndex < 0 || roomIndex >= rooms.Length) return;

        // 현재 방 비활성화
        rooms[currentRoomIndex].SetActive(false);

        // 새로운 방 활성화
        currentRoomIndex = roomIndex;
        rooms[currentRoomIndex].SetActive(true);
    }
}
