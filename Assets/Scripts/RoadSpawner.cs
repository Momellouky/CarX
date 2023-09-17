using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject road;
    public float spawnRate = 20.0f;
    private float timer = 2;
    private Vector3 initPosition;
    private Vector3 roadPosition;
    public const float INCREMENT_FACTOR = 580.957764f;
    private const float INIT_X = 61.7f; 
    private const float INIT_Y = 3.3f; 
    private const float INIT_Z = 1.0f;
    private float previousZ = INIT_Z; 

    // Start is called before the first frame update
    void Start()
    {
        initPosition = new Vector3(INIT_X, INIT_Y, INIT_Z); 
        spawnRoad(initPosition); 
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += 3;
        }
        else
        {
            roadPosition = new Vector3(INIT_X, INIT_Y, previousZ + INCREMENT_FACTOR); 
            spawnRoad(roadPosition);
            previousZ += INCREMENT_FACTOR; 
            timer = 0;
        }

    }

    private void spawnRoad(Vector3 roadPos) {
        Instantiate(road, roadPos, transform.rotation);
    }
}
