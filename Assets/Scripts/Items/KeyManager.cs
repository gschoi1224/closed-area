using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    private bool triggerOn = false;
    private PlayerMove thePlayer;
    public string settext;
    public GameObject inventoryItem;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMove>();
    }

    void Update()
    {
        // 플레이어가 아이템과 충돌하고 특정 키를 눌렀을 때 아이템 장착
        if (triggerOn && thePlayer.IsKeydown)
        {
            Debug.Log(this.name);
            if (this.name == "key_silver")
            {
                Debug.Log("get a silverkey");
                thePlayer.hasSilverKey = true;
                gameObject.SetActive(false);
                TextLoader.instance.SetText(settext);
                InventoryManager.instance.addItem(inventoryItem);
            }
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
