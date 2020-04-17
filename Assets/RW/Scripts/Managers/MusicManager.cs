using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;    // store reference of SoundManager

    public AudioClip backgroundMusic;

    private Vector3 cameraPosition;         // position of camera

    // Awake runs before the start method
    // it is useful when trying to reference the SoundManager Instance from
    // other scripts without running into timing problems
    void Awake()
    {
        Instance = this;
        cameraPosition = Camera.main.transform.position;
        PlayBackground();
    }

    // play the desired clip
    private void PlaySound(AudioClip clip)
    {
        // play the audioclip at the camera's position
        AudioSource.PlayClipAtPoint(clip, cameraPosition);
    }

    public void PlayBackground()
    {
        PlaySound(backgroundMusic);
    }
}
