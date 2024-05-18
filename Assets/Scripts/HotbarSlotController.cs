using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HotbarSlotController
{
    public static Dictionary<Items, int> _hotbar = new();
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

    public static bool AddItem(Items item)
    {
        if (_hotbar.ContainsKey(item))
        {
            if (_hotbar[item] >= _maxItem[item])
                return false;
            _hotbar[item]++;
        }
        else
            _hotbar.Add(item, 1);
        return true;
    }

    public static bool RemoveItem(Items item)
    {
        if (!_hotbar.ContainsKey(item) || _hotbar[item] <= 0)
            return false;
        _hotbar[item]--;
        return true;
    }
}