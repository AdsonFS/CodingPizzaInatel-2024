using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public Vector2 movement;
    public int CurrentDay;
    public string Tasks;
    // Start is called before the first frame update
    void Start()
    {
        DiarieController.UpdateTask();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Tasks = DiarieController.GetTasks;
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
