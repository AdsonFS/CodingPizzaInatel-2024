using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static List<Item> _hotbar = new();
    public Item[] AllItems;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    public InventorySlot newItemSlot;

    private Dictionary<ItemType, List<(ItemType itemType, int qt)>> ItemsDependency = new()
    {
        { ItemType.SPEAR, new(){ (ItemType.STICK, 1)}},
        { ItemType.TORCH, new(){ (ItemType.STICK, 1), (ItemType.GRASS, 1)}},
        { ItemType.HAMMER, new(){ (ItemType.STONE, 1), (ItemType.STICK, 1)}},
        { ItemType.AXE, new(){ (ItemType.ROCK, 1), (ItemType.STICK, 1)}},
    };

    public void Test(Item item){

    }

    public bool AddItem(Item item){
        if (_hotbar.Count(x => x.type == item.type) > _maxItem[item.type])
            return false;

        _hotbar.Add(item);

        foreach(var inventorySlot in inventorySlots){
            var itemInSlow = inventorySlot.GetComponentInChildren<InventoryItem>();
            if(itemInSlow == null){
                SpawnNewItem(item, inventorySlot);
                break;
            }
        }

        DiarieController.CheckDay(_hotbar);

        foreach(var possibleNewItem in ItemsDependency)
        {
            if(_hotbar.Count(x => x.type == possibleNewItem.Key) > 0)
                continue;
            
            bool canBeGenerated = true;
            foreach(var ItemDependency in possibleNewItem.Value){
                if(_hotbar.Count(x => x.type == ItemDependency.itemType) < ItemDependency.qt){
                    canBeGenerated = false;
                }
            }

            if(canBeGenerated){
                newItemSlot.gameObject.SetActive(true);
                var newItem = AllItems.First(x => x.type == possibleNewItem.Key);
                AddItem(newItem);
                SpawnNewItem(newItem, newItemSlot);
            }
        }

        return true;
    }

    void SpawnNewItem(Item item, InventorySlot inventorySlot){
        GameObject newItem = Instantiate(inventoryItemPrefab, inventorySlot.transform);
        InventoryItem inventoryItem = newItem.GetComponent<InventoryItem>();
        inventoryItem.InitializeItem(item);
    }

    public bool hasItem(ItemType itemType, int qt = 1){
        return _hotbar.Count(x => x.type == itemType) >= qt;
    }


    private static Dictionary<ItemType, int> _maxItem = new()
    {
        { ItemType.GRASS, 99 },
        { ItemType.WOOD, 99 },
        { ItemType.AXE, 1 },
        { ItemType.SPEAR, 1 },
        { ItemType.STICK, 99 },
        { ItemType.HAMMER, 1 },
        { ItemType.STONE, 99 },
        { ItemType.TORCH, 99 },
        { ItemType.BERRY, 99 },
        { ItemType.COCUNUT, 99 }
    };
}
