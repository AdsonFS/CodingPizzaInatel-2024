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
    STICK,
    TORCH,
    GRASS,
    STONE,
    ROCK,
    HAMMER,
    AXE,
    WOOD,
    SPEAR,
    BOTTLE,
    BERRY,
    COCUNUT,
    BOAT
}
