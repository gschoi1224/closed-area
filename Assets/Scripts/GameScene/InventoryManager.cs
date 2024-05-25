using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    private List<GameObject> itemList = new List<GameObject>();
    private GameObject activeItem;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void addItem(GameObject item)
    {
        if (activeItem != null)
        {
            activeItem.SetActive(false);
        }

        itemList.Add(item);
        activeItem = item;
        activeItem.SetActive(true);
    }

    public void removeActiveItem()
    {
        Debug.Log(itemList);
        if (activeItem != null)
        {
            itemList.Remove(activeItem);
            activeItem.SetActive(false);

            if (itemList.Count > 0)
            {
                activeItem = itemList[itemList.Count - 1];
                activeItem.SetActive(true);
            }
            else
            {
                activeItem = null;
            }
        }
    }

    public void removeSpecificItem(GameObject item)
    {
        if (itemList.Contains(item))
        {
            if (activeItem == item)
            {
                itemList.Remove(item);
                activeItem.SetActive(false);

                if (itemList.Count > 0)
                {
                    activeItem = itemList[itemList.Count - 1];
                    activeItem.SetActive(true);
                }
                else
                {
                    activeItem = null;
                }
            }
            else
            {
                itemList.Remove(item);
            }
        }
    }

    public void useActiveItem()
    {
        // 아이템 사용 로직 추가
        // 예시: 아이템 사용 후 삭제
        if (activeItem != null)
        {
            removeActiveItem();
        }
    }
}
