using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// these two are used to easily access other classes
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/*
 * To inherit from IPointerClickHandler interface allows this callse to
 * receive OnPointerClick callbacks from the event system.
 */
public class StartButton : MonoBehaviour, IPointerClickHandler
{
    /*
     * PointerEventData hold all information for the click event
     */
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("Game"); // load the Game scene
    }
}
