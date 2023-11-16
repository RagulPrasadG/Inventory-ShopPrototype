using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIService : MonoBehaviour
{

    [SerializeField] TMP_Text messageText;

    [Space(10)]
    [Header("SERVICES")]
    [SerializeField] ShopService shopService;
    [SerializeField] InventoryService inventoryService;

    [Space(10)]
    [Header("INVENTORY & SHOP PANELS")]
    [SerializeField] ItemInfoPanel itemInfoPanel;
    [SerializeField] ItemManagePanel itemManagePanel;
    [SerializeField] ConfirmationPanel confirmationPanel;


    private EventService eventService;

    public void Init(EventService eventService)
    {
        this.eventService = eventService;
        this.itemInfoPanel.Init(eventService);
        this.itemManagePanel.Init(eventService);
        this.confirmationPanel.Init(eventService);
        shopService.Init(this,eventService,itemInfoPanel, itemManagePanel, confirmationPanel);
        inventoryService.Init(this,eventService,itemInfoPanel,itemManagePanel,confirmationPanel);
    }

    public void ShowMessage(string message)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
    }

}
