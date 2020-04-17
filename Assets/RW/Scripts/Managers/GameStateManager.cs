using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // we can use scene related methods

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    [HideInInspector]           // don't show the variable on the editor
    public int sheepSaved;      // the amount of sheep that were saved
    [HideInInspector]
    public int sheepDropped;    // number of sheep that fell down

    public int sheepDroppedBeforeGameOver;  // amount of sheep that can be dropped
    public SheepSpawner sheepSpawner;       // reference to sheepSpawner

    
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        // if the Escape key is pressed, load the title screen
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    
    }

    public void SavedSheep()
    {
        sheepSaved++;

        UIManager.Instance.UpdateSheepSaved(); // update the text of sheep saved
    }

    private void GameOver()
    {
        sheepSpawner.canSpawn = false;      // stop spawining sheep
        sheepSpawner.DestroyAllSheep();     // destroy all sheep

        UIManager.Instance.ShowGameOverWindow(); // show game over window
    }

    // this method is called every time a sheep falls down
    public void DroppedSheep()
    {
        sheepDropped++;
        if (sheepDropped == sheepDroppedBeforeGameOver)
        {
            GameOver();
        }

        UIManager.Instance.UpdateSheepDropped(); // update the text of dropped sheep
    }
}
