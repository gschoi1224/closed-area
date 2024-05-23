using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDiary : MonoBehaviour
{
    private bool triggerOn = false;
    private PlayerMove thePlayer;
    public GameObject Canvas;
    public GameObject Inventory;
    public GameObject Text;
    private bool isReadingDiary = false;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
    }

    void Update()
    {
        // 플레이어가 아이템과 충돌하고 특정 키를 눌렀을 때 아이템 장착
        if (triggerOn && thePlayer.IsKeydown)
        {
                Inventory.SetActive(false);
                Canvas.SetActive(true);
                Text.SetActive(true);
                isReadingDiary = true;   
        }
        // 플레이어가 연구 일지를 읽고 있을 때, 다른 키를 눌러 상태를 벗어나기
        if (isReadingDiary && Input.anyKeyDown)
        {
            isReadingDiary = false;
            Text.SetActive(false);
            Canvas.SetActive(false);
            Inventory.SetActive(true);
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
