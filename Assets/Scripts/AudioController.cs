using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance { get; private set; }

    [Space()]

    [SerializeField]
    public AudioMixer AudioMixer;

    [Space()]

    [SerializeField]
    private AudioSource _clipAudioSource;
    [SerializeField]
    private AudioSource _backgroundAudioSource;

    [SerializeField]
    private List<AudioClip> _sfxClips;
    [SerializeField]
    private List<AudioClip> _bgClips;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        //LoadAudioSettings();
    }

    private void Start()
    {
        AudioMixer.SetFloat(Settings.MASTER_VOLUME, Mathf.Log10(PlayerPrefs.GetFloat(Settings.MASTER_VOLUME, 1f)) * 20);
        AudioMixer.SetFloat(Settings.BACKGROUND_VOLUME, Mathf.Log10(PlayerPrefs.GetFloat(Settings.BACKGROUND_VOLUME, 1f)) * 20);
        AudioMixer.SetFloat(Settings.SFX_VOLUME, Mathf.Log10(PlayerPrefs.GetFloat(Settings.SFX_VOLUME, 1f)) * 20);
    }

    public void PlayAmmoPickupSound()
    {
        _clipAudioSource.PlayOneShot(_sfxClips[0]);
    }   

    public void SetBackgroundMusic(int index)
    {
        _backgroundAudioSource.Stop();
        _backgroundAudioSource.clip = _bgClips[index];
        _backgroundAudioSource.Play();
    }

    public void LoadAudioSettings()
    {
        AudioMixer.SetFloat(Settings.MASTER_VOLUME, Mathf.Log10(PlayerPrefs.GetFloat(Settings.MASTER_VOLUME, 1f)) * 20);
        AudioMixer.SetFloat(Settings.BACKGROUND_VOLUME, Mathf.Log10(PlayerPrefs.GetFloat(Settings.BACKGROUND_VOLUME, 1f)) * 20);
        AudioMixer.SetFloat(Settings.SFX_VOLUME, Mathf.Log10(PlayerPrefs.GetFloat(Settings.SFX_VOLUME, 1f)) * 20);
    }
}
