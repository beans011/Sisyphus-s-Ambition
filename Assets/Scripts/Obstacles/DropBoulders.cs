using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBoulders : MonoBehaviour
{
    [SerializeField] private GameObject boulder;
    public float spawnInterval;

    private float timer;

    private void Start()
    {
        SpawnBoulder();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnBoulder();
            timer = 0f;
        }
    }

    void SpawnBoulder()
    {
        Instantiate(boulder, transform.position, Quaternion.identity);
    }
}
