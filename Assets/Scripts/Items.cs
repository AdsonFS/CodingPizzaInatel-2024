using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public Items Type;
    public SpriteRenderer spriteRenderer;
}

public enum Items
{
    GRASS,
    WOOD,
    AXE,
    FISH,
    SPEAR,
    STICK,
    HAMMER,
    STONE,
    TORCH,
    BERRY,
    POISONBERRY
}
