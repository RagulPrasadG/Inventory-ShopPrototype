using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryService: MonoBehaviour
{
    [SerializeField] TMP_Text inventoryWeightText;
    [SerializeField] RectTransform itemContainer;
    [SerializeField] ItemViewUI inventorySlotPrefab;
    [SerializeField] ItemDataScriptableObject itemDataScriptableObject;
    [SerializeField] Button gatherResourcesButton;

    [Space(10)]
    [Header("Stats")]
    [SerializeField] int maxWeight;
    

    #region SubPanels
    private ItemInfoPanel itemInfoPanel;
    private ItemManagePanel itemManagePanel;
    private ConfirmationPanel confirmationPanel;
    #endregion 

    private List<ItemControllerUI> inventoryItems = new List<ItemControllerUI>();
    private ItemControllerUI selectedItem;
    private float inventoryWeight;

    private GameService gameService;
    private EventService eventService;
    private UIService uIservice;

    private void OnDisable()
    {
        eventService.OnSellFromInfoPanel.RemoveListener(ShowItemManagePanel);
        eventService.OnBuyFromInfoPanel.RemoveListener(ShowItemManagePanel);
    }

    public void AddRandomItem()
    {
        ItemData randomItemData = itemDataScriptableObject.GetRandomItemData();
        ItemControllerUI itemController = null;
        foreach(ItemControllerUI itemControllerUI in inventoryItems)
        {
            ItemData itemData = itemControllerUI.GetData();
//if we find an item that is at its maxstack then continue on to find the same item that has not reached its max stack
            if (itemData.itemName == randomItemData.itemName)
            {
                if (itemData.quantity == itemData.maxStack)           
                {
                    continue;
                }   
                else
                {
                    itemController = itemControllerUI;
                    break;
                }
                  
            }
        }

        if (itemController != null)
        {
            ItemData itemData = itemController.GetData();
            if (itemData.isStackable && itemData.quantity < itemData.maxStack)
            {
                if(this.inventoryWeight + itemData.weight > this.maxWeight)
                {
                    uIservice.ShowMessage("Cannot add more item!!!");
                    return;
                }
                itemData.quantity++;
                IncreaseInventoryWeight(itemData.weight);
                itemController.SetData(itemData);
                return;
            }
        }
        CreateItemSlot(randomItemData);
    }

    public void AddItem(ItemData itemToadd)
    {
        ItemControllerUI itemController = null;
        foreach (ItemControllerUI itemControllerUI in inventoryItems)
        {
            ItemData itemData = itemControllerUI.GetData();
            //if we find an item that is at its maxstack then continue on to find the same item that has not reached its max stack
            if (itemData.itemName == itemToadd.itemName)
            {
                if (itemData.quantity == itemData.maxStack)
                {
                    continue;
                }
                else
                {
                    itemController = itemControllerUI;
                    break;
                }
            }
        }

        if (itemController != null)
        {
            ItemData itemData = itemController.GetData();
            if (itemData.isStackable && itemData.quantity < itemData.maxStack)
            {
                if (this.inventoryWeight + itemData.weight > this.maxWeight)
                {
                    uIservice.ShowMessage("Cannot add more item!!!");
                    return;
                }
                itemData.quantity++;
                IncreaseInventoryWeight(itemData.weight);
                itemController.SetData(itemData);
                return;
            }
        }
        CreateItemSlot(itemToadd);
    }


    public void CreateItemSlot(ItemData itemData)
    {
        if (this.inventoryWeight  >= this.maxWeight)
        {
            uIservice.ShowMessage("The inventory is Full!!!");
            return;
        }

        ItemControllerUI itemControllerUI = new ItemControllerUI(inventorySlotPrefab);
        itemControllerUI.SetData(itemData);
        itemControllerUI.SetParent(itemContainer);
        itemControllerUI.OnItemSelected(OnItemSelected);
        inventoryItems.Add(itemControllerUI);
        IncreaseInventoryWeight(itemData.weight);
    }

    public void Init(GameService gameService,UIService uIservice,EventService eventService,ItemInfoPanel itemInfoPanel,
        ItemManagePanel itemManagePanel,
        ConfirmationPanel confirmationPanel)
    {
        this.gameService = gameService;
        this.eventService = eventService;
        this.uIservice = uIservice;
        this.itemInfoPanel = itemInfoPanel;
        this.itemManagePanel = itemManagePanel;
        this.confirmationPanel = confirmationPanel;
        SetEvents();
    }

    public void SetEvents()
    {
        eventService.OnSellFromInfoPanel.AddListener(ShowItemManagePanel);
        eventService.OnSellFromManagePanel.AddListener(ShowConfirmationPanel);
        eventService.OnSellFromConfirmationPanel.AddListener(SellItem);
        eventService.OnBuyItem.AddListener(AddItem);
        gatherResourcesButton.onClick.AddListener(GatherResources);
    }

    public void GatherResources() => AddRandomItem();
 

    public void SellItem(ItemData sellingItemdata)
    {
        ItemData selecteditemData = selectedItem.GetData();
        if (selecteditemData.quantity > sellingItemdata.quantity)
        {
            selecteditemData.quantity -= sellingItemdata.quantity;
            DecreaseInventoryWeight(selecteditemData.weight);
        }
        else
        {
            inventoryItems.Remove(selectedItem);
            DecreaseInventoryWeight(selecteditemData.weight);
            selectedItem.DestroyItem();
        }
        uIservice.ShowMessage($"You gained {sellingItemdata.sellingprice} coins!!");
        selectedItem.SetData(selecteditemData);

        this.eventService.OnSellItem.RaiseEvent(sellingItemdata);
    }


    public void ShowItemManagePanel(ItemData itemData)
    {
        itemManagePanel.SetItemInfoUI(itemData);
        itemManagePanel.gameObject.SetActive(true);
    }

    public void OnItemSelected(ItemControllerUI itemControllerUI)
    {
        selectedItem = itemControllerUI;
        ShowInfoPanel(selectedItem.GetData());
    }

    public void ShowInfoPanel(ItemData itemData)
    {
        itemInfoPanel.SetItemInfo(itemData, true);
        itemInfoPanel.gameObject.SetActive(true);
    }

    public void DecreaseInventoryWeight(float weight)
    {
        this.inventoryWeight -= weight;
        SetInventoryWeightText();
    }

    public void IncreaseInventoryWeight(float weight)
    {
        this.inventoryWeight += weight;
        SetInventoryWeightText();
    }

    public void SetInventoryWeightText()
    {
        this.inventoryWeightText.text = $"{inventoryWeight}kg";
    }

    public void ShowConfirmationPanel(ItemData itemData)
    {
        confirmationPanel.SetItemData(itemData,true);
        confirmationPanel.SetSellMessageText(itemData);
        confirmationPanel.gameObject.SetActive(true);
    }


}
