using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventService
{
    #region InfoPanel
    public EventController<ItemData> OnSellFromInfoPanel;
    public EventController<ItemData> OnBuyFromInfoPanel;
    #endregion 

    #region ManagePanel
    public EventController<ItemData> OnSellFromManagePanel;
    public EventController<ItemData> OnBuyFromManagePanel;
    #endregion

    #region ConfirmationPanel
    public EventController<ItemData> OnSellFromConfirmationPanel;
    public EventController<ItemData> OnBuyFromConfirmationPanel;
    #endregion

    public EventController<ItemData> OnSellItem;
    public EventController<ItemData> OnBuyItem;
    public EventService()
    {
        OnSellFromInfoPanel = new EventController<ItemData>();
        OnBuyFromInfoPanel = new EventController<ItemData>();
        OnSellFromManagePanel = new EventController<ItemData>();
        OnBuyFromManagePanel = new EventController<ItemData>();
        OnSellFromConfirmationPanel = new EventController<ItemData>();
        OnSellItem = new EventController<ItemData>();
        OnBuyItem = new EventController<ItemData>();
        OnBuyFromConfirmationPanel = new EventController<ItemData>();
    }


}
