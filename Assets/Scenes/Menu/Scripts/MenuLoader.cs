using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject boat;
    public Image boatSprite;
    public GameObject marzo;
    public GameObject menuInterface;
    public float movespeed;

    void Start()
    {
        marzo.SetActive(false);
        menuInterface.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (boat.transform.position.x > 100){
            marzo.SetActive(true);
            menuInterface.SetActive(true);
            boatSprite.color = Color.red;
            return;
        }

        boat.transform.position = 
            new Vector2(boat.transform.position.x + movespeed * Time.deltaTime, boat.transform.position.y + movespeed * Time.deltaTime);
    }
}
