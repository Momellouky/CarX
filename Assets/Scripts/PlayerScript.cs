using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float turnSpeed = 1.0f;
    public float boostSpeed = 15f;
    private float currentSpeed;

    public float horizontalInput;
    public GameObject coin;
    public int scoreValue = 0;
    //public GameObject prefab; // red car
    private bool i = false;
    private bool j = false;
    private Rigidbody rb;
    private bool isBoosting = false;
    private float boostTimeLeft = 0f;

    private float rotationFactor = 2.0f; 




    // Start is called before the first frame update
    void Start()
    {
        // Generate a random position
        Vector3 position = new Vector3(Random.Range(-7, 0), Random.Range(0, 0), Random.Range(7, 25));
        //Vector3 position2 = new Vector3(Random.Range(0, 7), Random.Range(0, 0), Random.Range(7, 25));
        // Instantiate the prefab at the random position
        //Instantiate(prefab, position, Quaternion.identity);
        //Instantiate(prefab, position2, Quaternion.identity);
        rb = GetComponent<Rigidbody>();
        currentSpeed = speed;

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        //move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        // transform.Translate(Vector3.right*Time.deltaTime*turnSpeed*horizontalInput);
        transform.Rotate(Vector3.up, horizontalInput * rotationFactor);
        // Invoke("minus", 0f);
        if (!i && Mathf.Abs(transform.position.x) >= 8)
        {
            scoreValue -= 5;
            Debug.Log("Game Over " + scoreValue);
            i = true;
            // Game Over 
        }
        if (Mathf.Abs(transform.position.x) < 8)
        {
            i = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isBoosting && scoreValue >= 15)
        {
            isBoosting = true;
            boostTimeLeft = 1.5f;
        }



    }

    private void FixedUpdate()
    {
        if (isBoosting)
        {
            currentSpeed = boostSpeed;
            boostTimeLeft -= Time.deltaTime;
            if (boostTimeLeft <= 0f)
            {
                isBoosting = false;
                currentSpeed = speed;
            }
            rb.velocity = transform.forward * currentSpeed;
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, 50);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            SpawnCoin();
            Destroy(GameObject.FindWithTag("coin"));
            scoreValue += 10;
            Debug.Log(scoreValue);
        }
        if (collision.gameObject.CompareTag("obstacle") || collision.gameObject.CompareTag("redCar"))
        {
            scoreValue -= 5;
            Debug.Log(scoreValue);
        }
        if (collision.gameObject.CompareTag("checkpoint") && !j)
        {
            SpawnScene();
            // Destroy(GameObject.FindWithTag("lastScene"));
            // spawn = false;
        }
    }

    void OnBecameInvisible()
    {
        j = false;
    }

    private void SpawnCoin()
    {
        GameObject coin = GameObject.FindWithTag("coin");
        Vector3 spawnPosition = coin.transform.position + new Vector3(0, 0, Random.Range(10f, 30f));
        GameObject newCoin = Instantiate(coin, spawnPosition, coin.transform.rotation);
        newCoin.tag = "coin";
    }

    private void SpawnScene()
    {
        GameObject scene = GameObject.FindWithTag("lastScene");
        Vector3 spawnPosition = scene.transform.position + new Vector3(0, 0, 199);
        GameObject newScene = Instantiate(scene, spawnPosition, Quaternion.identity);
        newScene.tag = "lastScene";
        // scene.tag = "lastScene";
        j = true;
    }

}
