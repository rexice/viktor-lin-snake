using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class control : MonoBehaviour
{
    //Script for the snake
    private float speed = 0.3f;

    Vector3 dir = Vector3.right;

    List<Transform> tail = new List<Transform>();

    public GameObject tailPrefab;

    public GameObject gameOverUI;

    public static bool isDead = false;
    bool ate = false;


    void Start()
    {
        //moves every 0,3s
        InvokeRepeating("Move", 0.3f, speed);
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name.StartsWith("score"))
        {
            ate = true;

            Destroy(coll.gameObject);
        }
        else if (coll.name.StartsWith("Boost"))
        {
            this.speed += 0.5f;
            Destroy(coll.gameObject);
        }
        else if (coll.name.StartsWith("Tail"))
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
            isDead = true;
        }
        else if (coll.name.StartsWith("Bomb"))
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
            isDead = true;
        }

        //Screenrap, where the snake comes out from other side when entering the border
        else if (coll.gameObject.CompareTag("Right"))
        {
            transform.position = new Vector3(-27, transform.position.y, transform.position.z);
            Debug.Log("Hit");

        }

        else if (coll.gameObject.CompareTag("Left"))
        {
            transform.position = new Vector3(27, transform.position.y, transform.position.z);
        }
        else if (coll.gameObject.CompareTag("Up"))
        {

            transform.position = new Vector3(transform.position.x, -16, transform.position.z);

        }
        else if (coll.gameObject.CompareTag("Down"))
        {

            transform.position = new Vector3(transform.position.x, 16, transform.position.z);

        }
    }

    void Update()
    {
        //using both arrow keys and wasd to change direction
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            dir = Vector3.right;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            dir = -Vector3.up;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            dir = -Vector3.right;
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            dir = Vector3.up;
        }
    }

    void Move()
    {
        Vector3 v = transform.position;

        transform.Translate(dir);

        if (ate)
        {
            GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);

            tail.Insert(0, g.transform);

            ate = false;
        }

        else if (tail.Count > 0)
        {
            tail.Last().position = v;

            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

}

