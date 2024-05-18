using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item item;

    public void PickupItem(){
        inventoryManager.AddItem(item);
    }
}
