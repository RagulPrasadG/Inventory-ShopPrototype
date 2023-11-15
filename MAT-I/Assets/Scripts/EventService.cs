using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventService
{
    #region InfoPanel
    public EventController<ItemData> OnSellFromInfoPanel;
    public EventController<ItemData> OnBuyFromInfoPanel;
    #endregion 

    public EventService()
    {
        OnSellFromInfoPanel = new EventController<ItemData>();
        OnBuyFromInfoPanel = new EventController<ItemData>();
    }

}
