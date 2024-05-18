using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiarieController
{
    public static int maskTasks = 0;
    public static string Note = "";
    public static string Tasks = "";
    private static List<string> diary = new()
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


    private static List<Dictionary<Items, int>> nedeedItems = new()
    {
        { new Dictionary<Items, int> { { Items.STICK, 2 }, { Items.STONE, 1 } } },
        { new Dictionary<Items, int> { { Items.WOOD, 5 } } },
        { new Dictionary<Items, int> { { Items.FISH, 5 } } },
        { new Dictionary<Items, int> { { Items.STONE, 5 } } },
        { new Dictionary<Items, int> { { Items.GRASS, 5 } } },
        { new Dictionary<Items, int> { { Items.STICK, 5 } } },
        { new Dictionary<Items, int> { { Items.BERRY, 5 } } },
        { new Dictionary<Items, int> { { Items.POISONBERRY, 5 } } },
        { new Dictionary<Items, int> { { Items.BERRY, 5 } } },
        {  new Dictionary<Items, int> { { Items.WOOD, 5 } } }
    };

    private static List<int> dependencies = new() {
        -1,
        -1,
        1 << 0,
        1 << 1,
        1 << 2,
        1 << 3,
        1 << 3,
        1 << 4,
        1 << 5,
        1 << 6
    };

    public static string GetTasks => $"{Note}\n\n****************************************************\n\n{Tasks}\n";

    public static void UpdateTask()
    {
        Tasks = "";
        for (int i = 0; i < nedeedItems.Count; i++)
        {
            if ((maskTasks & (1 << i)) != 0) continue;
            if (dependencies[i] == -1 || ((maskTasks & (1 << i)) == 0 && (dependencies[i] & maskTasks) == dependencies[i]))
            {
                foreach (var item in nedeedItems[i])
                {
                    Tasks += $"- {diary[i]}\n";
                }
                Tasks += "\n";
            }
        }
    }
    public static void CheckDay()
    {
        bool update = false;
        for (int i = 0; i < nedeedItems.Count; i++)
        {
            bool ok = true;
            if ((maskTasks & (1 << i)) != 0) continue;
            foreach (var item in nedeedItems[i])
            {
                if (!HotbarSlotController._hotbar.ContainsKey(item.Key) || HotbarSlotController._hotbar[item.Key] < item.Value)
                    ok = false;
                continue;
            }
            if (ok) { maskTasks |= 1 << i; update = true; }
        }
        if (update) UpdateTask();
    }
}
