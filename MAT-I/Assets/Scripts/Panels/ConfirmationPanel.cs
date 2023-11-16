using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationPanel : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text messageText;
    [SerializeField] Button yesButton;
    [SerializeField] Button noButton;

    private EventService eventService;
    private ItemData itemData;
    private bool isSelling;

    private void OnYesButtonClicked()
    {
        if(isSelling)
           eventService.OnSellFromConfirmationPanel.RaiseEvent(this.itemData);
        else
           eventService.OnBuyFromConfirmationPanel.RaiseEvent(this.itemData);


        this.gameObject.SetActive(false);
    }

    public void Init(EventService eventService)
    {
        this.eventService = eventService;
        yesButton.onClick.AddListener(OnYesButtonClicked);
        noButton.onClick.AddListener(OnNoButtonClicked);
    }

    public void SetItemData(ItemData itemdata,bool isSelling)
    {
        this.itemData = itemdata;
        this.isSelling = isSelling;
    }

    public void SetBuyMessageText(ItemData itemdata)
    {
        messageText.text = $"Do you want to buy X{itemdata.quantity} of {itemdata.itemName} for {itemdata.buyingprice}";
    }

    public void SetSellMessageText(ItemData itemdata)
    {
        messageText.text = $"Do you want to sell X{itemdata.quantity} of {itemdata.itemName} for {itemdata.sellingprice}";
    }

    private void OnNoButtonClicked() => this.gameObject.SetActive(false);


}
