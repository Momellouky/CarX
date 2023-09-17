using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollisionDetection : MonoBehaviour
{
    private LogicScript logicScript; 
    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("LogicManager").GetComponent<LogicScript>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("CollisionDetected"); 
    }
}
