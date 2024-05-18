using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public Vector2 movement;
    public int CurrentDay;
    public string Tasks;
    public Text Text;
    // Start is called before the first frame update

    private int ind = 0;
    void Start()
    {
        DiarieController.UpdateTask();
        InvokeRepeating("updateText", 0.2f, 0.03f);
    }

    void updateText()
    {
        if (ind >= Tasks.Length) return;
        Text.text += Tasks[ind++];
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Tasks = DiarieController.GetTasks;
        // Text.text = Tasks;
    }

    void Move()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        transform.position += new Vector3(movement.x, movement.y, 0) * speed * Time.deltaTime;
        // float x = Input.GetAxis("Horizontal");
        // float y = Input.GetAxis("Vertical");

        // Vector3 move = new Vector3(x, y, 0);
        // transform.position += new Vector3movement * speed * Time.deltaTime;
    }
}
