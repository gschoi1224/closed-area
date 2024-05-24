using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverDoorManager : MonoBehaviour
{
    private bool isNearDoor = false;
    private bool isLock = true;
    private PlayerMove thePlayer;
    public string pressKey;
    public string needKey;
    public string openDoor;
    public GameObject Wall;

    private void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
    }

    private void Update()
    {
        if (isNearDoor && Input.GetKeyDown(KeyCode.A))
        {
            if (thePlayer.hasSilverKey && isLock)
            {
                // 문을 여는 로직 (예: 문을 비활성화하거나 다른 씬으로 이동)
                SoundManager.instance.PlayEffect(3);
                Debug.Log("The door is opened with the silver key!");
                TextLoader.instance.SetText(openDoor);
                Wall.SetActive(false);
                isLock = false;
            }
            else if (!thePlayer.hasSilverKey)
            {
                SoundManager.instance.PlayEffect(2);
                TextLoader.instance.SetText(needKey);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearDoor = true;
            // 플레이어가 열쇠가 없는 경우 문과 충돌을 처리
            if (!thePlayer.hasSilverKey)
            {
                // 문과 충돌할 때 플레이어를 멈추게 하거나 다른 로직을 추가
                TextLoader.instance.SetText(pressKey);
                SoundManager.instance.PlayEffect(2);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearDoor = false;
        }
    }
}
