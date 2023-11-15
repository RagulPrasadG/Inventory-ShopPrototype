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



}
