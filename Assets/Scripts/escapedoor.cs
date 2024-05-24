using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escapedoor : MonoBehaviour
{
    private bool triggerOn = false;
    private PlayerMove thePlayer;
    float timer = 0f;
    bool checkTimer = false;
    public bool canescape = false;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (checkTimer && timer > 1.5f)
        {
            // Clear the checkTimer flag if necessary
            checkTimer = false;
        }
        if (triggerOn && thePlayer.IsKeydown && !thePlayer.saveCat) // 탈출 불가
        {
            TextLoader.instance.SetText("cantescape");
        }
        else if (!checkTimer && triggerOn && thePlayer.IsKeydown && thePlayer.saveCat)
        {
            PlayerPrefs.SetInt("EndingReason", 0);
            TextLoader.instance.SetText("ClearDoor");
            SceneManager.LoadScene("EndingScene");
            timer = 0f;
            checkTimer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "fordoor")
        {
            triggerOn = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "fordoor")
        {
            triggerOn = true;
        }
    }
}
