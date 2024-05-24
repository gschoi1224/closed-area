using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondDoor : MonoBehaviour
{
    private bool isNearDoor = false;
    public bool isLock = true;
    private PlayerMove thePlayer;
    public GameObject Wall;

    private void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
    }

    private void Update()
    {
        if (isNearDoor && Input.GetKeyDown(KeyCode.A))
        {
            if (isLock)
            {
                // 문을 여는 로직 (예: 문을 비활성화하거나 다른 씬으로 이동)
                TextLoader.instance.SetText("NeedPassword");
            }
        }
    }

    public void OpenDoor()
    {
        Debug.Log("The door is opened with password!");
        TextLoader.instance.SetText("CorrectPassword");
        Wall.SetActive(false);
        isLock = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNearDoor = true;
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
