using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadScript : MonoBehaviour
{
    public GameObject road; 
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(road, new Vector3(transform.position.x, transform.position.y, transform.position.z * 3), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnRoad() { 
    
        Instantiate(road, new Vector3(transform.position.x, transform.position.y, transform.position.z * 3), transform.rotation);

    }
}
