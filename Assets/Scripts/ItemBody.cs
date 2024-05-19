using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ItemBody : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item item;
    public bool isColliding = false;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if (isColliding && Input.GetKeyDown(KeyCode.B) && HotbarSlotController.AddItem(item))
        {
            // play the sound
            audioSource.Play();
            // GetComponent<AudioSource>().Play();
            inventoryManager.AddItem(item);
=======
        if (isColliding && Input.GetKeyDown(KeyCode.B) && inventoryManager.AddItem(item)){
>>>>>>> 3484eac2839c86db4cef341c07a41ebb09b7e317
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            isColliding = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            isColliding = false;
    }
}
