using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable obj")]
public class Item : ScriptableObject
{
    [Header("Only gameplay")]
    public ItemType type;

    [Header("Both")]
    public Sprite image;
}

public enum ItemType
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
