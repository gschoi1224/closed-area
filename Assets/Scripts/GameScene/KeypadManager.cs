using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadManager : MonoBehaviour
{
    private bool triggerOn = false;
    private PlayerMove thePlayer;
    public GameObject PasswordCanvas;
    public GameObject Inventory;
    private bool isEnteringPassword = false;
    public bool isLock = true;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
    }

    void Update()
    {
        if (triggerOn && thePlayer.IsKeydown && isLock)
        {
            Inventory.SetActive(false);
            PasswordCanvas.SetActive(true);
            isEnteringPassword = true;
        }
        if (isEnteringPassword && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            isEnteringPassword = false;
            PasswordCanvas.SetActive(false);
            Inventory.SetActive(true);
        }
    }

    public void ExitCanvas(bool isCorrect)
    {
        isEnteringPassword = false;
        PasswordCanvas.SetActive(false);
        Inventory.SetActive(true);
        if (isCorrect)
        {
            isLock = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player") // Equals로 변경
        {
            Debug.Log("triggerOn is false");
            triggerOn = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Player") // Equals로 변경
        {
            Debug.Log("triggerOn is true");
            triggerOn = true;
        }
    }

}
