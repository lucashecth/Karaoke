using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class IncreasePitch : MonoBehaviour
{
    public AudioMixer musicLivePitch;
    public float actualPitch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangePitchUp()
    {
        musicLivePitch.GetFloat("Pitch", out actualPitch);
        musicLivePitch.SetFloat("Pitch", actualPitch + 0.01f );
    }
    public void ChangePitchDown()
    {
        musicLivePitch.GetFloat("Pitch", out actualPitch);
        musicLivePitch.SetFloat("Pitch", actualPitch - 0.01f);
    }
}
