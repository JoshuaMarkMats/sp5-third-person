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
    [SerializeField]
    private Slider miscSlider;
    [SerializeField]
    private TextMeshProUGUI miscVolumeText;

    private void Start()
    {
        masterSlider.onValueChanged.AddListener(delegate { MasterVolumeChanged(); }) ;
        bgSlider.onValueChanged.AddListener(delegate { BGVolumeChanged(); });
        sfxSlider.onValueChanged.AddListener(delegate { SFXVolumeChanged(); });
    }

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(masterSlider.gameObject);
    }

    private void MasterVolumeChanged()
    {
        AudioController.Instance.AudioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80f, 0f, masterSlider.value/100f));
        masterVolumeText.text = $"{masterSlider.value}";
    }

    private void BGVolumeChanged()
    {
        AudioController.Instance.AudioMixer.SetFloat("BackgroundVolume", Mathf.Lerp(-80f, 0f, bgSlider.value / 100f));
        bgVolumeText.text = $"{bgSlider.value}";
    }

    private void SFXVolumeChanged()
    {
        AudioController.Instance.AudioMixer.SetFloat("SFXVolume", Mathf.Lerp(-80f, 0f, sfxSlider.value / 100f));
        sfxVolumeText.text = $"{sfxSlider.value}";
    }
}
