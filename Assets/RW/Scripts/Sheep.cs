using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float runSpeed;              // speed meter
    public float gotHayDestroyDelay;    // delay from getting hit to destroyed
    private bool hitByHay;              // true if sheep is hit

    public float dropDestroyDelay;      // delay from touching the edge to destroyed
    private Collider myCollider;        // sheep's collider component
    private Rigidbody myRigidbody;      // sheep's rigidbody

    private SheepSpawner sheepSpawner;

    public float heartOffset;           // offset in Y axis where the heart will spawn
    public GameObject heartPrefab;      // heart reference

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hay") && !hitByHay)
        {
            Destroy(other.gameObject);  // destroy also the hay itself
            HitByHay();
        }
        else if (other.CompareTag("DropSheep"))
        {
            Drop();
        }
    }

    private void HitByHay()
    {
        sheepSpawner.RemoveSheepFromList(gameObject); // remove sheep from list

        hitByHay = true; 
        runSpeed = 0;       // stop sheep

        Destroy(gameObject, gotHayDestroyDelay);    // destroy sheep

        // create a heart and position it above the sheep
        Instantiate(heartPrefab, transform.position + new Vector3(0, heartOffset, 0), Quaternion.identity);

        // add a tweenscale component to the object
        TweenScale tweenScale = gameObject.AddComponent<TweenScale>();  
        tweenScale.targetScale = 0;                         // to shrink 100% the sheep                                
        tweenScale.timeToReachTarget = gotHayDestroyDelay;  // same time to destroy than to shrink

        SoundManager.Instance.PlaySheepHitClip();   // play sound

        GameStateManager.Instance.SavedSheep(); // tell the manager that the sheep is saved
    }

    private void Drop()
    {
        sheepSpawner.RemoveSheepFromList(gameObject); // remove sheep from list

        myRigidbody.isKinematic = false;        // set non-kinematic to be affected by gravity
        myCollider.isTrigger = false;           // unable trigger so the sheep becomes solid
        Destroy(gameObject, dropDestroyDelay);  // destroy sheep

        SoundManager.Instance.PlaySheepDroppedClip();   // play sound

        GameStateManager.Instance.DroppedSheep(); // tell the manager that a sheep is dropped
    }

    public void SetSpawner(SheepSpawner spawner)
    {
        sheepSpawner = spawner;
    }
}
