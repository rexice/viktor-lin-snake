using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScore : MonoBehaviour
{
    public GameObject scorePrefab;

    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    void Start()
    {
        // Spawn food every 4 seconds, starting in 2
        InvokeRepeating("Spawn", 4, 2);
    }

    void Spawn()
    {
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);

        int y = (int)Random.Range(borderBottom.position.y, borderTop.position.y);

        // Instantiate the food at (x, y)
        Instantiate(scorePrefab, new Vector2(x, y), Quaternion.identity);
    }

}
