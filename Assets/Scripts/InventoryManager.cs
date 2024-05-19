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
        { ItemType.AXE, new(){ (ItemType.HAMMER, 1)}}
    };

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


    private static Dictionary<ItemType, int> _maxItem = new()
    {
        { ItemType.GRASS, 99 },
        { ItemType.WOOD, 99 },
        { ItemType.AXE, 1 },
        { ItemType.FISH, 99 },
        { ItemType.SPEAR, 1 },
        { ItemType.STICK, 99 },
        { ItemType.HAMMER, 1 },
        { ItemType.STONE, 99 },
        { ItemType.TORCH, 99 },
        { ItemType.BERRY, 99 },
        { ItemType.COCUNUT, 99 }
    };
}
