using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryService: MonoBehaviour
{
    [SerializeField] RectTransform itemContainer;
    [SerializeField] ItemViewUI inventorySlotPrefab;
    [SerializeField] ItemDataScriptableObject itemDataScriptableObject;

    private List<ItemControllerUI> inventoryItems;

    public void Start()
    {
        
    }

    public void AddItem()
    {
        ItemData itemData = itemDataScriptableObject.GetItemData("BlueMedicine");
        //ItemControllerUI itemControllerUI = new ItemControllerUI(inventorySlotPrefab,)
    }

}
