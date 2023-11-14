using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData" , menuName = "Data/NewItemData")]
public class ItemDataScriptableObject : ScriptableObject
{
    public List<ItemData> items;

}

[System.Serializable]
public class ItemData
{
    public Sprite icon;
    public string description;
    public float buyingprice;
    public float sellingprice;
    public float weight;
    public Rarity rarity;
    public float quantity;
}

public enum ItemType
{
    Materials,
    Weapons,
    Consumables,
    Treasure
}

public enum Rarity
{
   VeryCommon,
   Common,
   Rare,
   Epic,
   Legendary
}

