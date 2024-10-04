using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item{
    public ItemType itemType;
    public int quantity;      // 物品数量

    public Item(ItemType type, int qty){
        itemType = type;
        quantity = qty;
    }
}

[System.Serializable]
public class Inventory{
    public Dictionary<ItemType, Item> items = new Dictionary<ItemType, Item>();

    // 添加物品到背包中
    public void AddItem(ItemType itemType, int quantity){
        // 检查字典中是否已经存在该物品类型
        if (items.ContainsKey(itemType))
        {
            // 如果物品已经存在，增加数量
            items[itemType].quantity += quantity;
        }
        else
        {
            // 如果物品不存在，添加到字典中
            items[itemType] = new Item(itemType, quantity);
        }
    }

    // 移除物品
    public void RemoveItem(ItemType itemType, int quantity){
        if (items.ContainsKey(itemType))
        {
            // 减少物品数量
            items[itemType].quantity -= quantity;

            // 如果物品数量为0或更少，则从字典中移除该物品
            if (items[itemType].quantity <= 0)
            {
                items.Remove(itemType);
            }
        }
    }

    // 获取物品数量
    public int GetItemQuantity(ItemType itemType){
        return items.ContainsKey(itemType) ? items[itemType].quantity : 0;
    }

    // 打印背包中的所有物品
    public void PrintInventory(){
        foreach (var item in items){
            Debug.Log($"Item: {item.Key}, Quantity: {item.Value.quantity}");
        }
    }
}
