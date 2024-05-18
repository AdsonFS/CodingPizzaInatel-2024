using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeColider : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public bool isColliding = false;

    void Update()
    {
        if (isColliding && spriteRenderer.color.a > 0.8f) spriteRenderer.color += new Color(0, 0, 0, -0.1f) * 3 * Time.deltaTime;
        else if (!isColliding && spriteRenderer.color.a < 1f) spriteRenderer.color += new Color(0, 0, 0, 0.1f) * 3 * Time.deltaTime;
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
