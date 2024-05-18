using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable obj")]
public class Item : ScriptableObject
{
    [Header("Only gameplay")]
    public ItemType type;
    public ActionType actionType;

    [Header("Only UI")]
    public bool Stackable = true;

    [Header("Both")]
    public Sprite image;


    public enum ItemType
    {
        Tool
    }

    public enum ActionType
    {
        Cut,
        Atack
    }
}
