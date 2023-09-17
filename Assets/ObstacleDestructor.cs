using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestructor : MonoBehaviour
{
    public GameObject playerCar;
    private float deathZone = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerCar = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCar.transform.position.z > transform.position.z + deathZone)
        {
            Destroy(gameObject);
        }

    }
}
