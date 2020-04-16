using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingHay : MonoBehaviour
{
    public float movementSpeed;
    // the boundary is the number of "positions" the MovingHay can move in one direction
    public float horizontalBoundary = 22;
    public GameObject hayBalePrefab;    // object hayBale
    public Transform haySpawnpoint;     // where the hayBale should appear from
    public float shootInterval;         // time between shots
    private float shootTimer;           // current time between shots

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateShooting();
    }

    private void UpdateMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // gets a value between -1 and 1

        // if value < 0 it means that the left key is pressed
        if (horizontalInput < 0 && transform.position.x > -horizontalBoundary)
        {
            transform.Translate(transform.right * -movementSpeed * Time.deltaTime);
        }
        // if value > 0 it means that the right key is pressed
        else if (horizontalInput > 0 && transform.position.x < horizontalBoundary)
        {
            transform.Translate(transform.right * movementSpeed * Time.deltaTime);
        }

        // to check the x position at current moment:
        //Debug.Log(transform.position.x);
    }

    private void UpdateShooting()
    {
        shootTimer -= Time.deltaTime;

        if(shootTimer <= 0 && Input.GetKey(KeyCode.Space))
        {
            shootTimer = shootInterval;
            ShootHay();
        }
    }

    private void ShootHay()
    {
        // create an instance of hayBalePrefab and place it in scene
        // with initial position haySpawnpoint
        // with initial rotation Quaternion.identity (which is the same as a Vector3 of zeros)
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
        SoundManager.Instance.PlayShootClip();
    }

}
