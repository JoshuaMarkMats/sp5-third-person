using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VideoSettings : MonoBehaviour
{
    [SerializeField]
    private Slider scaleSlider;
    [SerializeField]
    private TextMeshProUGUI scaleText;

    public const string UI_SCALE = "UIScale";

    private void Start()
    {
        scaleSlider.wholeNumbers = true;
        scaleSlider.minValue = 1;
        scaleSlider.maxValue = 4;
        scaleSlider.onValueChanged.AddListener((float value) => UIScaleChanged((int)value)) ;
        scaleSlider.value = PlayerPrefs.GetInt(UI_SCALE, 4);

        scaleText.text = scaleSlider.value.ToString();
    }

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(scaleSlider.gameObject);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt(UI_SCALE, (int)scaleSlider.value);
    }

    private void UIScaleChanged(int value)
    {
        CanvasScaleHandler.Instance.SetScale(value);
        scaleText.text = scaleSlider.value.ToString();
        AudioController.Instance.PlaySFX(1);
        
    }
}
