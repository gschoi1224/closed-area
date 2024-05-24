using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDoor : MonoBehaviour
{
    private bool isNearDoor = false;
    private bool isLock = true;
    private PlayerMove thePlayer;
    public GameObject Wall;
    public GameObject Monster;

    private void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
    }

    private void Update()
    {
        if (isNearDoor && Input.GetKeyDown(KeyCode.A))
        {
            if (thePlayer.hasSilverKey && isLock && !thePlayer.hasRedKey)
            {
                // 키가 없음
                TextLoader.instance.SetText("MismatchKey");
            }
            else if (isLock && thePlayer.hasRedKey)
            {
                // 문을 여는 로직 (예: 문을 비활성화하거나 다른 씬으로 이동)
                TextLoader.instance.SetText("CorrectPassword");
                Wall.SetActive(false);
                isLock = false;
                Monster.SetActive(true);
            }
            else if (!thePlayer.hasRedKey)
            {
                TextLoader.instance.SetText("mainupdoor");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearDoor = true;
            // 플레이어가 열쇠가 없는 경우 문과 충돌을 처리
            if (!thePlayer.hasRedKey)
            {
                // 문과 충돌할 때 플레이어를 멈추게 하거나 다른 로직을 추가
                TextLoader.instance.SetText("TutorialDoor");
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
