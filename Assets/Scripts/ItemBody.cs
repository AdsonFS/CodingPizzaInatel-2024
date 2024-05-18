using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ItemBody : MonoBehaviour
{
    public Items Type;
    public SpriteRenderer spriteRenderer;

    public bool isColliding = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isColliding && Input.GetKeyDown(KeyCode.B) && HotbarSlotController.AddItem(new Item { Type = Type, spriteRenderer = spriteRenderer }))
            Destroy(gameObject);

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
