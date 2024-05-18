using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;

    public void AddItem(Item item){
        foreach(var inventorySlot in inventorySlots){
            var itemInSlow = inventorySlot.GetComponentInChildren<InventoryItem>();
            if(itemInSlow == null){
                SpawnNewItem(item, inventorySlot);
                return;
            }
        }
    }

    void SpawnNewItem(Item item, InventorySlot inventorySlot){
        GameObject newItem = Instantiate(inventoryItemPrefab, inventorySlot.transform);
        InventoryItem inventoryItem = newItem.GetComponent<InventoryItem>();
        inventoryItem.InitializeItem(item);
    }
}
