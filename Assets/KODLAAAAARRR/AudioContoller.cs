using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioContoller : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioClip;
    void Start()
    {
        audioClip.Play();
        DontDestroyOnLoad(audioClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
