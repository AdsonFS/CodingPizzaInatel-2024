using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EndGameBoat : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject marzoEnd;
    public GameObject player;
    public List<Transform> path;
    public int index = 0;
    public float delta;
    public bool isFinished = false;

    void Start()
    {
        isFinished = true;
        player.gameObject.transform.SetParent(marzoEnd.gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isFinished) return;
        if(index >= path.Count){
            SceneManager.LoadScene("End");
            isFinished = false;
            return;
        }
        if(Mathf.Abs(Vector3.Distance(marzoEnd.gameObject.transform.position, path[index].position)) < 1) {
            index++;
        } else {
            marzoEnd.gameObject.transform.position = Vector3.MoveTowards(marzoEnd.gameObject.transform.position, path[index].position, delta);
        }
    }
}
