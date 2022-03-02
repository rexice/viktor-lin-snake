using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScore : MonoBehaviour
{
    //Spawn different object on the level

    public GameObject scorePrefab;
    public GameObject boostPrefab;
    public GameObject bombPrefab;

    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    void Start()
    {
        // Spawn food every 4 seconds, starting in 2
        InvokeRepeating("Spawn", 2, 4);

        // Spawn food every 10 seconds, starting in 10
        InvokeRepeating("spawnBoost", 10, 10);

        // Spawn food every 30 seconds, starting in 30
        InvokeRepeating("spawnBomb", 30, 30);
    }

    void Spawn()
    {
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);

        int y = (int)Random.Range(borderBottom.position.y, borderTop.position.y);

        Instantiate(scorePrefab, new Vector2(x, y), Quaternion.identity);
    }

    void spawnBoost()
    {
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);

        int y = (int)Random.Range(borderBottom.position.y, borderTop.position.y);

        Instantiate(boostPrefab, new Vector2(x, y), Quaternion.identity);
    }

    void spawnBomb()
    {
        int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);

        int y = (int)Random.Range(borderBottom.position.y, borderTop.position.y);

        Instantiate(bombPrefab, new Vector2(x, y), Quaternion.identity);
    }



}
