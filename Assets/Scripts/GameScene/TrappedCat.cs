using UnityEngine;

public class TrappedCat : MonoBehaviour
{
    private bool triggerOn = false;
    private PlayerMove thePlayer;
    public GameObject EmptyBox;
    public GameObject InventoryItem;

    void Start()
    {
        SoundManager.instance.PlayEffect(4);
        thePlayer = FindObjectOfType<PlayerMove>();
    }

    void Update()
    {
        // 플레이어가 아이템과 충돌하고 특정 키를 눌렀을 때 아이템 장착
        if (triggerOn && thePlayer.IsKeydown)
        {
            SoundManager.instance.PlayEffect(3);
            thePlayer.saveCat = true;
            EmptyBox.SetActive(true);
            gameObject.SetActive(false);
            TextLoader.instance.SetText("SaveCat");
            InventoryManager.instance.addItem(InventoryItem);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player") // Equals로 변경
        {
            triggerOn = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player") // Equals로 변경
        {
            triggerOn = true;
        }
    }
}
