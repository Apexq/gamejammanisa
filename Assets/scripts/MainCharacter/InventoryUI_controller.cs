using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI_controller : MonoBehaviour
{
    public slotUI[] slots = new slotUI[9];
    private InventoryController playerInventory;

    private void Start()
    {
        playerInventory = GameObject.FindWithTag("Player").gameObject.GetComponent<InventoryController>();
    }

    public void updateImage(int index, Sprite newIcon)
    {
        slots[index].updateImage(index, newIcon, playerInventory);
    }

    public void updateText(int index, int itemCount)
    {
        slots[index].updateText(index, itemCount, playerInventory);
    }
}
