using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenScale : MonoBehaviour
{
    public float targetScale;           // final scale
    public float timeToReachTarget;     // time (sec) to reach target scale
    private float startScale;           // scale of object when the script is activated
    private float percentScaled;        // value to keep track of the scale

    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (percentScaled < 1f)
        {
            percentScaled += Time.deltaTime / timeToReachTarget;
            // performa a linear interpolation between start scale and target scale at the percentage specified
            float scale = Mathf.Lerp(startScale, targetScale, percentScaled);
            transform.localScale = new Vector3(scale, scale, scale);

        }
    }
}
