using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public float speed = 10;
    BirdScript scoreImport;

    void Start()
    {
        scoreImport = GameObject.FindGameObjectWithTag("scoreExport").GetComponent<BirdScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreImport.score < 1)
        {
            transform.position += (Vector3.left * speed) * Time.deltaTime;
        }
        else
        {
            transform.position += (Vector3.left * (speed + (scoreImport.score * 0.9f))) * Time.deltaTime;
        }
        // destroying pipes...
        if (gameObject.transform.position.x <= -55)
        {
            Destroy(gameObject);
        }
    }
}
