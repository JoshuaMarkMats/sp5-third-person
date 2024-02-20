using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private Slider masterSlider;
    [SerializeField]
    private TextMeshProUGUI masterVolumeText;
    [SerializeField]
    private Slider bgSlider;
    [SerializeField]
    private TextMeshProUGUI bgVolumeText;
    [SerializeField]
    private Slider sfxSlider;
    [SerializeField]
    private TextMeshProUGUI sfxVolumeText;

    public const string MASTER_VOLUME = "MasterVolume";
    public const string BACKGROUND_VOLUME = "BackgroundVolume";
    public const string SFX_VOLUME = "SFXVolume";

    private void Start()
    {
        masterSlider.onValueChanged.AddListener(delegate { MasterVolumeChanged(); }) ;
        bgSlider.onValueChanged.AddListener(delegate { BGVolumeChanged(); });
        sfxSlider.onValueChanged.AddListener(delegate { SFXVolumeChanged(); });

        masterSlider.value = PlayerPrefs.GetFloat(MASTER_VOLUME, 1f);
        bgSlider.value = PlayerPrefs.GetFloat(BACKGROUND_VOLUME, 1f);
        sfxSlider.value = PlayerPrefs.GetFloat(SFX_VOLUME, 1f);

        masterVolumeText.text = $"{(int)(masterSlider.value * 100)}";
        bgVolumeText.text = $"{(int)(bgSlider.value * 100)}";
        sfxVolumeText.text = $"{(int)(sfxSlider.value * 100)}";
    }

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(masterSlider.gameObject);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(MASTER_VOLUME, masterSlider.value);
        PlayerPrefs.SetFloat(BACKGROUND_VOLUME, bgSlider.value);
        PlayerPrefs.SetFloat(SFX_VOLUME, sfxSlider.value);
    }

    private void MasterVolumeChanged()
    {
        AudioController.Instance.AudioMixer.SetFloat("MasterVolume", Mathf.Approximately(masterSlider.value, 0f) ? -80f : Mathf.Log10(masterSlider.value) * 20);
        masterVolumeText.text = $"{(int)(masterSlider.value * 100)}";

        
    }

    private void BGVolumeChanged()
    {
        AudioController.Instance.AudioMixer.SetFloat("BackgroundVolume", Mathf.Approximately(bgSlider.value, 0f) ? -80f : Mathf.Log10(bgSlider.value) * 20);
        bgVolumeText.text = $"{(int)(bgSlider.value * 100)}";
    }

    private void SFXVolumeChanged()
    {
        AudioController.Instance.AudioMixer.SetFloat("SFXVolume", Mathf.Approximately(sfxSlider.value, 0f) ? -80f : Mathf.Log10(sfxSlider.value) * 20);
        sfxVolumeText.text = $"{(int)(sfxSlider.value * 100)}";
    }
}
