using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;    // store reference of SoundManager

    public AudioClip shootClip;             // shooting sound effect
    public AudioClip sheepHitClip;          // get hit sound effect
    public AudioClip sheepDroppedClip;      // drop sound effect

    private Vector3 cameraPosition;         // position of camera

    // Awake runs before the start method
    // it is useful when trying to reference the SoundManager Instance from
    // other scripts without running into timing problems
    void Awake()
    {
        Instance = this;
        cameraPosition = Camera.main.transform.position;
    }


    // play the desired clip
    private void PlaySound(AudioClip clip)
    {
        // play the audioclip at the camera's position
        AudioSource.PlayClipAtPoint(clip, cameraPosition);
    }

    public void PlayShootClip()
    {
        PlaySound(shootClip);
    }

    public void PlaySheepHitClip()
    {
        PlaySound(sheepHitClip);
    }

    public void PlaySheepDroppedClip()
    {
        PlaySound(sheepDroppedClip);
    }
}
