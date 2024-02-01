using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    [Space()]

    [SerializeField]
    public AudioMixer AudioMixer;

    [Space()]

    [SerializeField]
    private AudioSource ammoPickupSound;
    [SerializeField]
    private AudioSource backgroundMusic;

    /*private float masterVolume = 1f;
    private float bgVolume = 1f;
    private float sfxVolume = 1f;

    public float MasterVolume
    {
        get { return masterVolume; }
        set
        {
            masterVolume = value;
        }
            
            
    }
    public float BGVolume
    {
        get { return bgVolume; }
        set
        {
            bgVolume = value;
        }


    }
    public float SFXVolume
    {
        get { return sfxVolume; }
        set
        {
            sfxVolume = value;
        }


    }*/

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    /*public void UpdateBGSounds()
    {
        backgroundMusic.volume = bgVolume * masterVolume;
    }

    public void UpdateSFXSounds()
    {
        ammoPickupSound.volume = sfxVolume * masterVolume;
        
    }*/

    public void PlayAmmoPickupSound()
    {
        ammoPickupSound.Play();
    }   
}
