using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipe : MonoBehaviour
{
    [SerializeField] GameObject pipe;
    [SerializeField] float spawnRate = 2;
    private float timer = 0;
    [SerializeField] float heightOffset = 10;

    void Awake()
    {
        PipeSpawner();
    }


    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            PipeSpawner();
            timer = 0;
        }

    }

    void PipeSpawner()
    {
        float lowestHeight = transform.position.y - heightOffset;
        float highestHeight = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestHeight, highestHeight), 0), transform.rotation);
    }

}
