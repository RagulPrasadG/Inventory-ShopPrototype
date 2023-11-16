using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData" , menuName = "Data/NewItemData")]
public class ItemDataScriptableObject : ScriptableObject
{
    public List<ItemData> items;

    public ItemData GetItemData(string name)
    {
        return items.Find(itemdata => itemdata.itemName == name);
    }

    public ItemData GetRandomItemData()
    {
        return items[Random.Range(0, items.Count)];
    }

    //public ItemData? GetRandomItemData()
    //{
    //    return null;
    //}

}

[System.Serializable]
public struct ItemData
{
    public string itemName;
    public Sprite icon;
    [TextArea]
    public string description;
    public int buyingprice;
    public int sellingprice;
    public float weight;
    public ItemType itemType;
    public Rarity rarity;
    public int quantity;
    public bool isStackable;
    public int maxStack;
}

public enum ItemType
{
    Materials,
    Weapons,
    Consumables,
    Treasure
}

public enum ItemStatus
{
    Buying,Selling
}

public enum Rarity
{
   VeryCommon,
   Common,
   Rare,
   Epic,
   Legendary
}

