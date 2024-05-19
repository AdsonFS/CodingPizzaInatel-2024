using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;

public class InsideCave : MonoBehaviour
{
    // Start is called before the first frame update

    public Light2D light2D;
    public GameObject internalCave;
    public GameObject externalCave;
    public InventoryManager inventoryManager;

    public GameObject warningUI;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            externalCave.SetActive(false);
            if(inventoryManager.hasItem(ItemType.TORCH)){
                light2D.intensity = 0.1f;
            }else{
                light2D.intensity = 0.01f;
                warningUI.SetActive(true);
                warningUI.GetComponent<TextMeshProUGUI>().SetText("Consiga uma tocha!");
            }
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            externalCave.SetActive(true);
            light2D.intensity = 0.4f;
        }
    }

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
