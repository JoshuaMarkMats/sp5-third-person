using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
        float masterVolume = PlayerPrefs.GetFloat(AudioSettings.MASTER_VOLUME, 1f);
        float backgroundVolume = PlayerPrefs.GetFloat(AudioSettings.BACKGROUND_VOLUME, 1f);
        float sfxVolume = PlayerPrefs.GetFloat(AudioSettings.SFX_VOLUME, 1f);

        AudioMixer.SetFloat(AudioSettings.MASTER_VOLUME, Mathf.Approximately(masterVolume, 0f) ? -80f : Mathf.Log10(masterVolume) * 20);
        AudioMixer.SetFloat(AudioSettings.BACKGROUND_VOLUME, Mathf.Approximately(backgroundVolume, 0f) ? -80f : Mathf.Log10(backgroundVolume) * 20);
        AudioMixer.SetFloat(AudioSettings.SFX_VOLUME, Mathf.Approximately(sfxVolume, 0f) ? -80f : Mathf.Log10(sfxVolume) * 20);
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
}
