using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
 * IPointerEnterHandler and IPointerExitHandler supply methods for when
 * the pointer enters and exits the GameObject
 */
public class ChangeColorOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public MeshRenderer model;  // reference to mesh renderer which color will change
    public Color normalColor;   // default color
    public Color hoverColor;    // color when the pointer is on the model

    // Start is called before the first frame update
    void Start()
    {
        // change the model's color to the normal one
        model.material.color = normalColor;
    }

    /*
     * it gets called when the pointer enters the GameObject and
     * changes the color of the model's material
     */
    public void OnPointerEnter(PointerEventData eventData)
    {
        model.material.color = hoverColor;
    }

    /*
     * resets the color to the original one once the pointer
     * exits the model
     */
    public void OnPointerExit(PointerEventData eventData)
    {
        model.material.color = normalColor;
    }
}
