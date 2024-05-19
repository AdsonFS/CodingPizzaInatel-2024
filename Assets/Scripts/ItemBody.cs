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
        if (isColliding && Input.GetKeyDown(KeyCode.B) && inventoryManager.AddItem(item))
        {
            // play the sound
            audioSource.Play();
            // GetComponent<AudioSource>().Play();
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
