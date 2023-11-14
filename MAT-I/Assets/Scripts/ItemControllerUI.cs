using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControllerUI
{
    private ItemViewUI itemViewUI;
    private ItemData itemData;

    public ItemControllerUI(ItemViewUI itemViewUI)
    {
        this.itemViewUI = Object.Instantiate(itemViewUI);
        this.itemViewUI.SetController(this);
    }

    public void SetData(ItemData itemData)
    {
        this.itemData = itemData;
    }

    public ItemData GetData() => itemData;
}
