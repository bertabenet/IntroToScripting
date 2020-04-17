using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;   // reference to this UI Manager

    public Text sheepSavedText;         // reference to saved sheep text
    public Text sheepDroppedText;       // reference to dropeed sheep text
    public GameObject gameOverWindow;   // reference to gameover window


    void Awake()
    {
        Instance = this;
    }

    // get the amount of sheep saved from game state manager, convert it
    // to a string and use it to set the text of sheepSavedText
    public void UpdateSheepSaved()
    {
        sheepSavedText.text = GameStateManager.Instance.sheepSaved.ToString();
    }

    public void UpdateSheepDropped()
    {
        sheepDroppedText.text = GameStateManager.Instance.sheepDropped.ToString();
    }

    public void ShowGameOverWindow()
    {
        gameOverWindow.SetActive(true);
    }
}
