using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class HayMachineSwitcher : MonoBehaviour, IPointerClickHandler
{
    // references of the machine model colors
    public GameObject blueHayMachine;
    public GameObject yellowHayMachine;
    public GameObject redHayMachine;

    private int selectedIndex;

    // gets called when clicking the object
    public void OnPointerClick(PointerEventData eventData)
    {
        // increment and loop through the color indices
        selectedIndex++;
        selectedIndex %= Enum.GetValues(typeof(HayMachineColor)).Length;

        // set the chosen color in GameSetting depending on the selected index
        // which is cast to an enum by adding (HayMachineColor) before the variable
        GameSettings.hayMachineColor = (HayMachineColor)selectedIndex;

        // enable and disable the machine color models
        switch (GameSettings.hayMachineColor)
        {
            case HayMachineColor.Blue:
                blueHayMachine.SetActive(true);
                yellowHayMachine.SetActive(false);
                redHayMachine.SetActive(false);
                break;

            case HayMachineColor.Yellow:
                blueHayMachine.SetActive(false);
                yellowHayMachine.SetActive(true);
                redHayMachine.SetActive(false);
                break;

            case HayMachineColor.Red:
                blueHayMachine.SetActive(false);
                yellowHayMachine.SetActive(false);
                redHayMachine.SetActive(true);
                break;
        }
    }
}
