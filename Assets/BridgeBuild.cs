using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BridgeBuild : MonoBehaviour
{
    public GameObject warningUI;
    public InventoryManager inventoryManager;
    public List<GameObject> gameObjects;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            if(inventoryManager.hasItem(ItemType.WOOD)){
                foreach(var x in gameObjects){
                    x.SetActive(true);
                }
            }
            else{
                warningUI.SetActive(true);
                warningUI.GetComponent<TextMeshProUGUI>().SetText("Consiga madeira!");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        
    }
}
