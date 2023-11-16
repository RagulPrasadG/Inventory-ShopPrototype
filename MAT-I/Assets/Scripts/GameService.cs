using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : MonoBehaviour
{
    [SerializeField] UIService uIService;
    private EventService eventService;
    public int coins { get; set; }

    private void OnDisable()
    {
        this.eventService.OnSellItem.RemoveListener(OnItemSold);
    }

    private void Start()
    {
        SetDependencies();
        SetEvents();
    }

    private void SetEvents()
    {
        this.eventService.OnSellItem.AddListener(OnItemSold);
    }

    public void IncreaseCoins(int amount)
    {
        this.coins += amount;
        uIService.SetCoinText();
    }

    private void OnItemSold(ItemData soldItem)
    {
        this.coins += soldItem.sellingprice;
        uIService.SetCoinText();
    }

    private void SetDependencies()
    {
        eventService = new EventService();
        uIService.Init(this,eventService);

    }

    

}
