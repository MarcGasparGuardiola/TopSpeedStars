using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerSound : MonoBehaviour
{
    public AudioSource engineSource;
    public AudioSource turboSource;
    public AudioSource impactSource;
    
    public void EngineSound()
    {
        if (!engineSource.isPlaying) engineSource.Play();
    }
    public void StopEngineSound()
    {
        engineSource.Stop();
    }
    public void TurboSound()
    {
        turboSource.Play();
    }
    public void ImpactSound()
    {
        impactSource.Play();
    }
}
