using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioSource backSound;
    public AudioSource selectSound;
    public void BackSound()
    {
        backSound.Play();
    }
    public void SelectSound()
    {
        selectSound.Play();
    }
}
