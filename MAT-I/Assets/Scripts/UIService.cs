using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIService : MonoBehaviour
{
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
        shopService.Init(eventService,itemInfoPanel, itemManagePanel, confirmationPanel);
        inventoryService.Init(eventService,itemInfoPanel,itemManagePanel,confirmationPanel);
    }

}
