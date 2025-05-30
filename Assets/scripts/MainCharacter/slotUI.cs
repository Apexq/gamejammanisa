using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slotUI : MonoBehaviour
{
    public void Setactive()
    {
        if (this.gameObject.GetComponent<Image>().color.a == 0)
        {
            this.gameObject.GetComponent<Image>().color = new Color(this.gameObject.GetComponent<Image>().color.r, this.gameObject.GetComponent<Image>().color.b, this.gameObject.GetComponent<Image>().color.g, 1);
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().enabled = true;

        }
        else
        {
            if (Convert.ToInt32(this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text) <= 0)
            {
                this.gameObject.GetComponent<Image>().color = new Color(this.gameObject.GetComponent<Image>().color.r, this.gameObject.GetComponent<Image>().color.b, this.gameObject.GetComponent<Image>().color.g, 0);
                this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "0";
                this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().enabled = false;
            }
        }
    }

    public void updateImage(int index, Sprite newIcon, InventoryController playerInventory)
    {
        Setactive();
        this.gameObject.GetComponent<Image>().sprite = newIcon;
        Setactive();
    }

    public void updateText(int index, int itemCount, InventoryController playerInventory)
    {
        Setactive();
        this.gameObject.GetComponent<Image>().transform.GetChild(0).gameObject.GetComponent<Text>().text = itemCount.ToString();
        Setactive();
    }
}
