using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private bool triggerOn = false;
    private PlayerMove thePlayer;
    public GameObject item; // 실제 게임 내 아이템
    public GameObject inventoryitem; // 인벤토리 내 아이템
    public string settext;

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
            if (this.name == "woodbox")
            {
                Debug.Log("get a flashlight");
                thePlayer.itemname = "flashlight";
                EquipFlashlight();
            }
        }
        
        // 플레이어가 아이템을 사용할 때
        if (thePlayer.useitem && thePlayer.itemname == "flashlight")
        {
            UseFlashlight();
        }
    }

    private void EquipFlashlight()
    {
        // 인벤토리 내 아이템 활성화
        inventoryitem.SetActive(true);
        TextLoader.instance.SetText(settext);
        thePlayer.haveitem = true;
        item.SetActive(false);
        this.GetComponent<BoxCollider2D>().enabled = false;
        triggerOn = false;
    }

    private void UseFlashlight()
    {
        // 인벤토리 내 아이템 비활성화
        inventoryitem.SetActive(false);
        thePlayer.haveitem = false;
        thePlayer.itemname = "";
        thePlayer.useflash = true;

        // 플레이어 손에 있는 flashlight와 light 활성화
        thePlayer.transform.GetChild(0).gameObject.SetActive(true); // flashlight 2D 활성화
        thePlayer.transform.GetChild(1).gameObject.SetActive(true); // light 2D 활성화
        thePlayer.animator.SetBool("lighton", true);
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
        if (collision.gameObject.name == "Player") // Equals로 변경
        {
            Debug.Log("triggerOn is true");
            triggerOn = true;
        }
    }
}