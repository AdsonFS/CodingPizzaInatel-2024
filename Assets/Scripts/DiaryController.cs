using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiarieController
{
    public int CurrentDay { get; private set; } = 0;
    public string Note = "";
    private List<string> _diary = new()
    {
        "Day 1: I have arrived on this island. I need to find a way to survive.",
        "Day 2: I have found some berries. I need to find a way to cook them.",
        "Day 3: I have found some wood. I need to find a way to build a shelter.",
        "Day 4: I have found some fish. I need to find a way to catch them.",
        "Day 5: I have found some stone. I need to find a way to make tools.",
        "Day 6: I have found some grass. I need to find a way to make rope.",
        "Day 7: I have found some sticks. I need to find a way to make a fire.",
        "Day 8: I have found some poison berries. I need to find a way to make a poison spear.",
        "Day 9: I have found some more berries. I need to find a way to make a torch.",
        "Day 10: I have found some more wood. I need to find a way to make a hammer."
    };

    private Dictionary<int, Dictionary<Items, int>> nedeedItems = new()
    {
        { 1, new Dictionary<Items, int> { { Items.BERRY, 5 }, { Items.WOOD, 3 } } },
        { 2, new Dictionary<Items, int> { { Items.WOOD, 5 } } },
        { 3, new Dictionary<Items, int> { { Items.FISH, 5 } } },
        { 4, new Dictionary<Items, int> { { Items.STONE, 5 } } },
        { 5, new Dictionary<Items, int> { { Items.GRASS, 5 } } },
        { 6, new Dictionary<Items, int> { { Items.STICK, 5 } } },
        { 7, new Dictionary<Items, int> { { Items.BERRY, 5 } } },
        { 8, new Dictionary<Items, int> { { Items.POISONBERRY, 5 } } },
        { 9, new Dictionary<Items, int> { { Items.BERRY, 5 } } },
        { 10, new Dictionary<Items, int> { { Items.WOOD, 5 } } }
    };

    public string GetDiary => $"{Note}\n\n****************************************************\n\n{_diary[CurrentDay]}\n";

    public bool CheckDay()
    {
        foreach (var item in nedeedItems[CurrentDay])
        {
            if (!HotbarSlotController._hotbar.ContainsKey(item.Key) || HotbarSlotController._hotbar[item.Key] < item.Value)
                return false;
        }

        return true;
    }
}
