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


    private void Start()
    {
        //moves every 0,3s
        InvokeRepeating("Move", 0.3f, speed);
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        //Different function activates on different object
        if (coll.name.StartsWith("score"))
        {
            ate = true;

            ScoreManager.instance.AddScore();

            Destroy(coll.gameObject);
        }
        else if (coll.name.StartsWith("boost"))
        {
            speed += 0.6f;
            Destroy(coll.gameObject);
        }
        //Game over when you collide both tail or bomb
        else if (coll.name.StartsWith("Tail"))
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
            isDead = true;
        }
        else if (coll.name.StartsWith("bomb"))
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
            isDead = true;
        }

        //Screenrap, where the snake comes out from other side when entering the border
        else if (coll.gameObject.CompareTag("Right"))
        {
            transform.position = new Vector3(-55, transform.position.y, transform.position.z);
            //Debug.Log("Hit");
        }
        else if (coll.gameObject.CompareTag("Left"))
        {
            transform.position = new Vector3(15, transform.position.y, transform.position.z);
        }
        else if (coll.gameObject.CompareTag("Top"))
        {

            transform.position = new Vector3(transform.position.x, -25, transform.position.z);

        }
        else if (coll.gameObject.CompareTag("Bot"))
        {

            transform.position = new Vector3(transform.position.x, 25, transform.position.z);

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

    private void Move()
    {
        //The tail moves after the head
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

