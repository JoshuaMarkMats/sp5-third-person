using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleButtonSounder : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    void Start()
    {
        Toggle toggle = GetComponent<Toggle>();



        //Toggle.onClick.AddListener(SoundClick);
        //button.OnPointerEnter.AddListener(SoundClick);
        //button.onClick.AddListener(SoundMouseOver);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioController.Instance.PlaySFX(2);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioController.Instance.PlaySFX(3);
    }
}
