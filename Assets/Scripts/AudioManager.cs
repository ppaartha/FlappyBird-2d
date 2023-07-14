using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{


    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    

    public AudioClip background,game_over,game_complete;
   

    // Start is called before the first frame update
    public void Startbgm()
    {
        musicSource.clip=background;
        musicSource.Play();

    }

    public void PlaySE(AudioClip clip)
    {
        musicSource.Pause();
        sfxSource.clip=clip;
        sfxSource.PlayOneShot(clip);
        // BgmSource.Play();

    }
    
}
