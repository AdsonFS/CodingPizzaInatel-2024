using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public Vector2 movement;
    public int CurrentDay;
    public string Tasks;

    private Rigidbody2D rb;
    private Animator anim;

    public AudioSource audioSource;
    public AudioClip audioClipBeach;
    public AudioClip audioClipForest;
    public AudioClip audioClipPantano;
    public AudioClip audioClipCave;
    private AudioClip current;
    private bool swapped = false;
    public int layer;
    // public Text Text;
    // Start is called before the first frame update

    // private int ind = 0;
    void Start()
    {
        audioSource.clip = audioClipBeach;
        current = audioClipBeach;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        DiarieController.UpdateTask();
        // InvokeRepeating("updateText", 5f, 3000f);
    }
    void soundSwap()
    {
        if (audioSource.volume > 0.15 && !swapped && current != audioSource.clip) audioSource.volume -= 0.30f * Time.deltaTime;
        else if (audioSource.volume <= 0.15 && !swapped && current != audioSource.clip)
        {
            audioSource.clip = current;
            audioSource.Play();
            swapped = true;


        }

        if (swapped)
        {
            audioSource.volume += 0.20f * Time.deltaTime;
            if (audioSource.volume >= .85) swapped = false;
        }

    }
    void updateText()
    {
        // current = audioClipForest;

        // audioSource.clip = audioClipForest;
        // audioSource.Play();
        // if (ind >= Tasks.Length) return;
        // Text.text += Tasks[ind++];
    }

    // Update is called once per frame
    void Update()
    {
        // update isLayerBeach
        if (layer == 10) current = audioClipCave;
        else if (layer == 9) current = audioClipForest;
        else if (layer == 8) current = audioClipPantano;
        else current = audioClipBeach;


        soundSwap();
        Move();
        Tasks = DiarieController.GetTasks;
        // Text.text = Tasks;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        layer = other.gameObject.layer;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 10) layer = 8;
        else layer = other.gameObject.layer - 1;
    }

    private string last = "";

    void SetAnim(string dir)
    {
        if (dir != "idle" && dir != last)
        {
            last = dir;
            anim.SetBool("idle", true);
            return;
        }
        last = dir;
        // if (dir != "idle") last = false;
        anim.SetBool("up", false);
        anim.SetBool("down", false);
        anim.SetBool("left", false);
        anim.SetBool("right", false);
        anim.SetBool("idle", false);
        anim.SetBool(dir, true);
    }

    void Move()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        transform.position += new Vector3(movement.x, movement.y, 0) * speed * Time.deltaTime;
        if (movement.y != 0)
        {
            if (movement.y > 0) SetAnim("up");
            else SetAnim("down");
        }
        else if (movement.x != 0)
        {
            if (movement.x > 0) SetAnim("right");
            else SetAnim("left");
        }

        else
            anim.SetBool("idle", true);
    }
}
