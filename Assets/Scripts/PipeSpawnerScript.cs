using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2; // units is seconds
    public float timer = 0;
    public float heightOffset = 10;
    public bool allowSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // spawns pipes at intervals
        if(timer < spawnRate) {
            timer += Time.deltaTime;
        } else if(allowSpawning) {
            spawnPipe();
            timer = 0;
        }
        
        // transform.position refers to the current game object's position
    }

    public void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
