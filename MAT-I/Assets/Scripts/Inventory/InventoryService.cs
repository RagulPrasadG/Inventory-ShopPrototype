using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryService: MonoBehaviour
{
    [SerializeField] ItemInfoPanel itemInfoPanel;
    [SerializeField] ItemManagePanel itemManagePanel;
    [SerializeField] RectTransform itemContainer;
    [SerializeField] ItemViewUI inventorySlotPrefab;
    [SerializeField] ItemDataScriptableObject itemDataScriptableObject;

    private List<ItemControllerUI> inventoryItems = new List<ItemControllerUI>();
    private EventService eventService;

    public void Start()
    {
        AddItem();
    }

    private void OnDisable()
    {
        eventService.OnSellFromInfoPanel.RemoveListener(ShowItemManagePanel);
        eventService.OnBuyFromInfoPanel.RemoveListener(ShowItemManagePanel);
    }

    public void AddItem()
    {
        ItemData itemData = itemDataScriptableObject.GetItemData("Necklace");
        ItemControllerUI itemControllerUI = new ItemControllerUI(inventorySlotPrefab);
        itemControllerUI.SetData(itemData);
        itemControllerUI.SetParent(itemContainer);
        itemControllerUI.OnItemSelected(ShowInfoPanel);
        inventoryItems.Add(itemControllerUI);
    }


    public void Init(EventService eventService)
    {
        this.eventService = eventService;

        eventService.OnSellFromInfoPanel.AddListener(ShowItemManagePanel);
        eventService.OnBuyFromInfoPanel.AddListener(ShowItemManagePanel);

        itemInfoPanel.Init(eventService);
        itemManagePanel.Init(eventService);
    }

    public void ShowItemManagePanel(ItemData itemData)
    {
        itemManagePanel.SetItemInfo(itemData);
        itemManagePanel.gameObject.SetActive(true);
    }

    public void ShowInfoPanel(ItemData itemData)
    {
        itemInfoPanel.SetItemInfo(itemData, true);
        itemInfoPanel.gameObject.SetActive(true);
    }

}
