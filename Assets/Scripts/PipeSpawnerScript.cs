using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    float timer = 0;
    float spawnRate = 3;
    BirdScript scoreImport;
    [SerializeField] GameObject pipe;
    // Start is called before the first frame update
    void Start()
    {
        scoreImport = GameObject.FindGameObjectWithTag("scoreExport").GetComponent<BirdScript>();
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= spawnRate)     // I guess, it will wait 200 frames for rendering the pipe
        {
            SpawnPipe();
            timer = 0;
            spawnRate -= 0.001f * scoreImport.score;
        }
        else
        {
            timer += Time.deltaTime;
        }
        // destroying the pipe...

    }

    void SpawnPipe()
    {
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(transform.position.y - 10, transform.position.y + 10), 0), transform.rotation);
    }
}
