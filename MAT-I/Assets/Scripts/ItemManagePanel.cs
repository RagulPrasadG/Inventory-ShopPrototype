using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemManagePanel : MonoBehaviour
{
    [Header("BUTTONS")]
    [SerializeField] Button buyButton;
    [SerializeField] Button sellButton;
    [SerializeField] Button increaseAmountbutton;
    [SerializeField] Button decreaseAmountbutton;

    [Space(10)]
    [Header("TEXT")]
    [SerializeField] TMP_Text itemWeightText;
    [SerializeField] TMP_Text itemCostText;
    [SerializeField] TMP_Text itemAmountText;
    [SerializeField] TMP_Text itemNameText;
    [Space(10)]
    [SerializeField] Image itemIcon;

    private EventService eventService;

    private void OnEnable()
    {
        this.eventService.OnSellFromInfoPanel.AddListener(OnManageSell);
        this.eventService.OnBuyFromInfoPanel.AddListener(OnManageBuy);
    }

    private void OnDisable()
    {
        this.eventService.OnSellFromInfoPanel.RemoveListener(OnManageSell);
        this.eventService.OnBuyFromInfoPanel.RemoveListener(OnManageBuy);
    }

    private void OnManageBuy(ItemData itemData)
    {
        ToggleButtons(false);
        buyButton.gameObject.SetActive(true);
    }

    private void OnManageSell(ItemData itemData)
    {
        ToggleButtons(false);
        sellButton.gameObject.SetActive(true);
    }

    public void SetItemInfo(ItemData itemData)
    {
        this.itemCostText.text = $"{itemData.sellingprice}";
        this.itemNameText.text = itemData.itemName;
        this.itemAmountText.text = $"X{itemData.quantity}";
        this.itemWeightText.text = $"{itemData.weight}kg";
        this.itemIcon.sprite = itemData.icon;
    }

    public void Init(EventService eventService)
    {
        this.eventService = eventService;
    }

    public void ToggleButtons(bool toggle)
    {
        sellButton.gameObject.SetActive(toggle);
        buyButton.gameObject.SetActive(toggle);
    }

}
