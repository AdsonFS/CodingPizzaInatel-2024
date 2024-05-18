using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

public class HotbarSlotController : MonoBehaviour
{
    public static List<Item> _hotbar = new();
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
        { ItemType.POISONBERRY, 99 }
    };

    public static bool AddItem(Item item)
    {
        if (_hotbar.Count(x => x.type == item.type) > _maxItem[item.type])
            return false;
        _hotbar.Add(item);
        DiarieController.CheckDay(_hotbar);
        return true;
    }

    public static bool RemoveItem(ItemType item)
    {
        _hotbar.Remove(_hotbar.Find(x => x.type == item));
        return true;
    }
}