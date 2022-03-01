using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class control : MonoBehaviour
{
    Vector3 dir = Vector3.right;

    List<Transform> tail = new List<Transform>();

    bool ate = false;

    public GameObject tailPrefab;

    void Start()
    {
        //moves every 0,3s
        InvokeRepeating("Move", 0.3f, 0.3f);
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name.StartsWith("score"))
        {
            ate = true;

            Destroy(coll.gameObject);
        }
        else
        {
            // ToDo 'You lose' screen
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) dir = Vector3.right;
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) dir = -Vector3.up;
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) dir = -Vector3.right;
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) dir = Vector3.up;

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
        // Do we have a Tail?
        else if (tail.Count > 0)
        {
            tail.Last().position = v;

            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }
}

