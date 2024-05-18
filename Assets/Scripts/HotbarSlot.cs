using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HotbarSlot : MonoBehaviour
{
    public List<Item> Hotbar = new();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Hotbar = HotbarSlotController._hotbar;
    }
}
