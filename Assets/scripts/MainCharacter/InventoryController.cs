using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryController : MonoBehaviour
{
    [Header("envanter")]
    public List<slot> inventorySlots = new List<slot>();
    public InventoryUI_controller inventoryUI_Controller;

    private Healt_Main PlayerhealthSystem;

    private int tempIndex;
    private slot tempSlot;
    private bool isSwaping = false;

    private void Start()
    {
        foreach (var slot in inventorySlots)
        {
            slot.maxCount = 5;
        }
        PlayerhealthSystem = GameObject.FindWithTag("Player").GetComponent<Healt_Main>();
    }

    public bool addItem(scItem item)
    {
        foreach (slot slot in inventorySlots)
        {
            if (slot.item == item && !slot.isfull && item.canStackable)
            {
                slot.ItemCount++;
                if (slot.ItemCount >= slot.maxCount)
                {
                    slot.isfull = true;
                }
                inventoryUI_Controller.updateImage(inventorySlots.IndexOf(slot), item.itemIcon);
                inventoryUI_Controller.updateText(inventorySlots.IndexOf(slot), slot.ItemCount);
                return true;
            }
            else if (slot.item == null)
            {
                slot.AddItemInSlot(item);
                slot.ItemCount = 1;
                if (!item.canStackable || slot.ItemCount >= slot.maxCount)
                {
                    slot.isfull = true;
                }
                inventoryUI_Controller.updateImage(inventorySlots.IndexOf(slot), item.itemIcon);
                inventoryUI_Controller.updateText(inventorySlots.IndexOf(slot), slot.ItemCount);
                return true;
            }
        }
        return false;
    }

    public bool removeItem(scItem item)
    {
        foreach (slot slot in inventorySlots)
        {
            if (slot.item == item)
            {
                slot.ItemCount--;
                if (slot.ItemCount <= 0)
                {
                    slot.isfull = false;
                }
                inventoryUI_Controller.updateImage(inventorySlots.IndexOf(slot), item.itemIcon);
                inventoryUI_Controller.updateText(inventorySlots.IndexOf(slot), slot.ItemCount);
                return true;
            }
        }
        return false;
    }

    public void clearAllItem()
    {
        // tum envanteri sikmek icin kullancam
    }

    public void swapItem(int index)
    {
        if (!isSwaping && inventorySlots[index].item != null)
        {
            tempIndex = index;
            tempSlot = inventorySlots[index];
            isSwaping = true;
        }
        else if (isSwaping)
        {
            if (index != tempIndex)
            {
                inventorySlots[tempIndex] = inventorySlots[index];
                inventorySlots[index] = tempSlot;

                if (inventorySlots[index] != null && inventorySlots[index].item != null)
                {
                    inventoryUI_Controller.updateImage(index, inventorySlots[index].item.itemIcon);
                    inventoryUI_Controller.updateText(index, inventorySlots[index].ItemCount);
                }
                else
                {
                    inventoryUI_Controller.updateImage(index, null);
                    inventoryUI_Controller.updateText(index, 0);
                }

                if (inventorySlots[tempIndex] != null && inventorySlots[tempIndex].item != null)
                {
                    inventoryUI_Controller.updateImage(tempIndex, inventorySlots[tempIndex].item.itemIcon);
                    inventoryUI_Controller.updateText(tempIndex, inventorySlots[tempIndex].ItemCount);
                }
                else
                {
                    inventoryUI_Controller.updateImage(tempIndex, null);
                    inventoryUI_Controller.updateText(tempIndex, 0);
                }
            }
            else
            {
                useItem(inventorySlots[index].item, index);
            }
            isSwaping = false;
            tempSlot = null;
            EventSystem.current.SetSelectedGameObject(null);
        }
    }

    private void useItem(scItem item, int index)
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("flag"))
        {
            if (addItem(collision.gameObject.GetComponent<ItemBehavior>().item))
            {
                Destroy(collision.gameObject);
            }
        }

        
    }
}

[System.Serializable]
public class slot
{
    public int ItemCount = 0;
    public int maxCount = 5;
    public bool isfull = false;
    public scItem item;

    public void AddItemInSlot(scItem item)
    {
        this.item = item;
    }
}
