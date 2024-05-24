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
                // 문이 닫혀있음
                TextLoader.instance.SetText("NeedPassword");
                SoundManager.instance.PlayEffect(2);
            }
        }
    }

    public void OpenDoor()
    {
        Debug.Log("The door is opened with password!");
        TextLoader.instance.SetText("CorrectPassword");
        Wall.SetActive(false);
        isLock = false;
        SoundManager.instance.PlayEffect(3);
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
