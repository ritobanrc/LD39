using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public bool enabled;
    // Update is called once per frame
    void Update()
    {
        if (enabled)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
