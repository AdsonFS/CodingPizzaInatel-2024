using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadGame", 62f);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadGame() { 
        SceneManager.LoadScene("Main2");
    }
}
