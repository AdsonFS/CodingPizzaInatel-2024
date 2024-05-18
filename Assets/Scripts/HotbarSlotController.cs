using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

public static class HotbarSlotController
{
    public static List<Item> _hotbar = new();
    private static Dictionary<Items, int> _maxItem = new()
    {
        { Items.GRASS, 99 },
        { Items.WOOD, 99 },
        { Items.AXE, 1 },
        { Items.FISH, 99 },
        { Items.SPEAR, 1 },
        { Items.STICK, 99 },
        { Items.HAMMER, 1 },
        { Items.STONE, 99 },
        { Items.TORCH, 99 },
        { Items.BERRY, 99 },
        { Items.POISONBERRY, 99 }
    };

    public static bool AddItem(Item item)
    {
        if (_hotbar.Count(x => x.Type == item.Type) > _maxItem[item.Type])
            return false;
        _hotbar.Add(item);
        DiarieController.CheckDay();
        return true;
    }

    public static bool RemoveItem(Items item)
    {
        _hotbar.Remove(_hotbar.Find(x => x.Type == item));
        return true;
    }
}