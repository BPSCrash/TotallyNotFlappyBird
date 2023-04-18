using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{

    public GameObject Pipe;
    public float spawnRate = 2;
    private float timer = 0;
    public float heigtOffset = 10;

    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {

        if(timer < spawnRate)
        {
            timer += Time.deltaTime;

        } else
        {
            spawnPipe();
            timer = 0;
        }

        
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heigtOffset;
        float highestPoint = transform.position.y + heigtOffset;

        Instantiate(Pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
