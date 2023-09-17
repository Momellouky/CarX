using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public GameObject obstacle;
    private Vector3 reference;
    private float distanceBetweenObstacles; // distance in the z-axis

    // Start is called before the first frame update
    void Start()
    {
        reference = new Vector3(0, 0, 0);
        distanceBetweenObstacles = 50.0f;
        Debug.Log("Set position to 0");
        // obstacle.transform.position = new Vector3(0,0,0);
        spawnObstancles(); 
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Debug Obstacle In Update");   
    }

    private void spawnObstancles() {
        distanceBetweenObstacles = (float)Random.Range(50, 100);
        Instantiate(obstacle, new Vector3(transform.position.x, transform.position.y, distanceBetweenObstacles), Quaternion.identity); 
    }
}
