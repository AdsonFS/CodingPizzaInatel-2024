using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update

    // get the frame UI
    public GameObject frame;
    public GameObject diary;
    public Text Text;
    public void PlayGame()
    {
        frame.SetActive(!frame.activeSelf);
    }
    public void Diary()
    {
        diary.SetActive(!diary.activeSelf);
        Text.text = DiarieController.GetTasks;
    }

}
