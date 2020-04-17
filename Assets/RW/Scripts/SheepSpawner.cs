using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    public bool canSpawn = true;                                            // if true, keep spawning
    public GameObject sheepPrefab;                                          // sheep prefab
    public List<Transform> sheepSpawnPositions = new List<Transform>();     // positions where to be spawned
    public float timeBetweenSpawns;                                         // time between spawning
    private List<GameObject> sheepList = new List<GameObject>();            // alive sheep

    public float timeToIncreaseDifficulty;                                  // time to decrease the time between spawns

    // Start is called before the first frame update
    void Start()
    {
        // to start a coroutine we have to do it like:
        StartCoroutine(SpawnRoutine());
        StartCoroutine(IncreaseDifficulty());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnSheep()
    {
        // choose random spawn point
        Vector3 randomPosition = sheepSpawnPositions[Random.Range(0, sheepSpawnPositions.Count)].position;
        // create new sheep in selected position and original rotation
        GameObject sheep = Instantiate(sheepPrefab, randomPosition, sheepPrefab.transform.rotation);
        sheepList.Add(sheep);                           // add sheep to list
        sheep.GetComponent<Sheep>().SetSpawner(this);   // add reference to sheep spawner
    }

    // Coroutines can run over multiple frames or seconds
    // It spawns a sheep, pause, and then spawn again
    // IEnumerator allows you to yield (pause and resume execution)
    private IEnumerator SpawnRoutine()
    {
        while (canSpawn)
        {
            SpawnSheep();   // spawn a new sheep
            // pause the execution of this coroutine for timeBetweenSpawns seconds
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    /*
     * Each timeToIncreaseDifficulty seconds, the time between spawns is reduced
     */
    private IEnumerator IncreaseDifficulty()
    {
        while (canSpawn)
        {
            timeBetweenSpawns -= 0.1f;

            yield return new WaitForSeconds(timeToIncreaseDifficulty);
        }
    }

    // destroy desired sheep
    public void RemoveSheepFromList(GameObject sheep)
    {
        sheepList.Remove(sheep);
    }

    // destroy all sheeps
    public void DestroyAllSheep()
    {
        foreach (GameObject sheep in sheepList)
        {
            Destroy(sheep);
        }
        sheepList.Clear();
    }
}
