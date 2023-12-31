using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;


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

    [Space(10)]
    [Header("HUD")]
    [SerializeField] TMP_Text coinText;

    private EventService eventService;
    private GameService gameService;

    public void Init(GameService gameService,SoundServiceScriptableObject soundService,EventService eventService)
    {
        this.gameService = gameService;
        this.eventService = eventService;
        this.itemInfoPanel.Init(eventService,this);
        this.itemManagePanel.Init(eventService,this);
        this.confirmationPanel.Init(eventService);
        shopService.Init(gameService, soundService, this,eventService,itemInfoPanel, itemManagePanel, confirmationPanel);
        inventoryService.Init(gameService,soundService,this,eventService);
        SetCoinText();
    }

    public void SetCoinText()
    {
        coinText.text = gameService.coins.ToString();
    }

    public void ShowMessage(string message)
    {
        messageText.gameObject.SetActive(true);
        messageText.text = message;
        var tween = messageText.DOFade(0, 2f);
        tween.onComplete += () => {
            messageText.DOFade(1, 0f);
            messageText.gameObject.SetActive(false);
        };
       
    }

    public void ShowItemInfoPanel() => itemInfoPanel.gameObject.SetActive(true);

    public void ShowItemManagePanel() => itemManagePanel.gameObject.SetActive(true);

    public void ShowConfirmationPanel() => confirmationPanel.gameObject.SetActive(true);


}
