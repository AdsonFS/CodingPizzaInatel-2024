using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideCave : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject internalCave;
    public GameObject externalCave;

    public bool isInsideColider = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            internalCave.SetActive(true);
            externalCave.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(!isInsideColider){
                externalCave.SetActive(true);
            }
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
