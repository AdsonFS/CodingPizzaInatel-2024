using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoatColider : MonoBehaviour
{
    public GameObject player;
    public GameObject MarzoEnd;

    public GameObject EndGame;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            player.GetComponent<SpriteRenderer>().enabled = false;
            EndGame.SetActive(true);
            MarzoEnd.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        
    }
}
