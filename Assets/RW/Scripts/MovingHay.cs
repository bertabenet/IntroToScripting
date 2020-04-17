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

    public Transform modelParent;       // the parent Transform of the model

    public GameObject blueModelPrefab; 
    public GameObject yellowModelPrefab;
    public GameObject redModelPrefab;

    // Start is called before the first frame update
    void Start()
    {
        LoadModel();
    }

    private void LoadModel()
    {
        Destroy(modelParent.GetChild(0).gameObject);        // destroy current model

        // instantiate a hay machine model prefab and parent it to modelParent
        switch (GameSettings.hayMachineColor)
        {
            case HayMachineColor.Blue:
                Instantiate(blueModelPrefab, modelParent);
                break;

            case HayMachineColor.Yellow:
                Instantiate(yellowModelPrefab, modelParent);
                break;

            case HayMachineColor.Red:
                Instantiate(redModelPrefab, modelParent);
                break;
        }
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
