using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopService : MonoBehaviour
{

    [Header("PANELS")]
    [SerializeField] ItemInfoPanel itemInfoPanel;
    [SerializeField] ItemManagePanel itemManagePanel;
    [SerializeField] ConfirmationPanel confirmationPanel;

    [Space(10)]
    [Header("CONTAINERS")]
    [SerializeField] RectTransform materialsContainer;
    [SerializeField] RectTransform weaponsContainer;
    [SerializeField] RectTransform treasuresContainer;
    [SerializeField] RectTransform consumablesContainer;

    [Space(10)]
    [Header("BUTTONS")]
    [SerializeField] Button materialsTab;
    [SerializeField] Button weaponsTab;
    [SerializeField] Button treasuresTab;
    [SerializeField] Button consumablesTab;

    [SerializeField] ItemDataScriptableObject itemsData;
    [SerializeField] ItemViewUI slotPrefab;

    private List<ItemControllerUI> shopItems = new List<ItemControllerUI>();
    private ItemControllerUI selectedItem;
    private EventService eventService;

    private void Start()
    {
        for(int i = 0;i<20;i++)
        {
            AddItem();
        }
    }

    public void AddItem()
    {
        ItemData itemData = itemsData.GetRandomItemData();
        ItemControllerUI itemControllerUI = new ItemControllerUI(slotPrefab);
        itemControllerUI.SetData(itemData);
        switch (itemData.itemType)
        {
            case ItemType.Materials:
                itemControllerUI.SetParent(materialsContainer);
                break;
            case ItemType.Consumables:
                itemControllerUI.SetParent(consumablesContainer);
                break;
            case ItemType.Weapons:
                itemControllerUI.SetParent(weaponsContainer);
                break;
            case ItemType.Treasure:
                itemControllerUI.SetParent(treasuresContainer);
                break;
        }

        itemControllerUI.OnItemSelected(OnItemSelected);
        shopItems.Add(itemControllerUI);
    }

    public void Init(EventService eventService)
    {
        this.eventService = eventService;
        SetEvents();
        itemInfoPanel.Init(eventService);
        itemManagePanel.Init(eventService);
        confirmationPanel.Init(eventService);
    }

    public void SetEvents()
    {
        eventService.OnBuyFromInfoPanel.AddListener(ShowItemManagePanel);
        eventService.OnBuyFromManagePanel.AddListener(ShowConfirmationPanel);
        eventService.OnBuyItem.AddListener(BuyItem);
        materialsTab.onClick.AddListener(OnClickMaterialsTab);
        treasuresTab.onClick.AddListener(OnClickTreasuresTab);
        consumablesTab.onClick.AddListener(OnClickConsumablesTab);
        weaponsTab.onClick.AddListener(OnClickWeaponsTab);
    }

    public void OnClickMaterialsTab()
    {
        TogglePanels(false);
        materialsContainer.gameObject.SetActive(true);
    }

    public void OnClickTreasuresTab()
    {
        TogglePanels(false);
        treasuresContainer.gameObject.SetActive(true);
    }

    public void OnClickConsumablesTab()
    {
        TogglePanels(false);
        consumablesContainer.gameObject.SetActive(true);
    }

    public void OnClickWeaponsTab()
    {
        TogglePanels(false);
        weaponsContainer.gameObject.SetActive(true);
    }

    public void BuyItem(ItemData itemdata)
    {
        Debug.Log("Bought!!");
    }

    public void OnItemSelected(ItemControllerUI itemControllerUI)
    {
        selectedItem = itemControllerUI;
        ShowInfoPanel(selectedItem.GetData());
    }

    public void ShowInfoPanel(ItemData itemData)
    {
        itemInfoPanel.SetItemInfo(itemData, false);
        itemInfoPanel.gameObject.SetActive(true);
    }

    public void TogglePanels(bool toggle)
    {
        materialsContainer.gameObject.SetActive(toggle);
        weaponsContainer.gameObject.SetActive(toggle);
        consumablesContainer.gameObject.SetActive(toggle);
        treasuresContainer.gameObject.SetActive(toggle);
    }

    public void ShowItemManagePanel(ItemData itemData)
    {
        itemManagePanel.SetItemInfoUI(itemData);
        itemManagePanel.gameObject.SetActive(true);
    }


    public void ShowConfirmationPanel(ItemData itemData)
    {
        confirmationPanel.SetItemData(itemData);
        confirmationPanel.SetBuyMessageText(itemData);
        confirmationPanel.gameObject.SetActive(true);
    }
} 
