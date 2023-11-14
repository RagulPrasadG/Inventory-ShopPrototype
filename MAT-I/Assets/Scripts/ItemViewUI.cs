using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemViewUI : MonoBehaviour
{
    [SerializeField] Image iconImage;
    [SerializeField] TMP_Text quantityText;
    private ItemControllerUI itemControllerUI;


    public void SetController(ItemControllerUI itemController)
    {
        this.itemControllerUI = itemController;
    }

    public void Init()
    {
        this.iconImage.sprite = itemControllerUI.GetData().icon;
        this.quantityText.text = $"X{itemControllerUI.GetData().quantity}";
    }

}
