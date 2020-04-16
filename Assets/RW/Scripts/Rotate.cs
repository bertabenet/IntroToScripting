using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MonoBehaviour --> general class that 
public class Rotate : MonoBehaviour
{
    public Vector3 rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // remember --> deltaTime is the time that has passed since the last frame
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
