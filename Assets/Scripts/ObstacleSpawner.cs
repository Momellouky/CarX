using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;
    public float spawnRate = 2.0f;
    private float timer = 2;
    private float offset = 10.0f;
    private float previousZ = 0; 
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("SPAWN THE FIRST OBSTACLE. "); 
        //Instantiate(obstacle, new Vector3(referencePos.x, referencePos.y, referencePos.z + 20), transform.rotation);
        Instantiate(obstacle, new Vector3(transform.position.x, transform.position.y, transform.position.z + 20), transform.rotation);
        previousZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += 1;
        }
        else
        {
            offset = Random.Range(20, 50);
            float xObstaclePosition = generateObstaclePosition();
            GameObject spawnedObject = spawnObstacles(xObstaclePosition, offset); 
            timer = 0;
        }
    }

    private GameObject spawnObstacles(float xPosition, float _Zoffset) {

        GameObject spawnedObject = Instantiate(obstacle, new Vector3(xPosition, transform.position.y, previousZ + _Zoffset), transform.rotation);
        previousZ += _Zoffset;
        return spawnedObject; 
    }

    private float generateObstaclePosition() {
        float extremeRightPos = 8.0f;
        float extremeLeftPos = -8.0f;

        float position = Random.Range(extremeLeftPos, extremeRightPos);

        return position; 
    }
}
