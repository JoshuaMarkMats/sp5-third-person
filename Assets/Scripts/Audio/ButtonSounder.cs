using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonSounder : MonoBehaviour, IPointerEnterHandler
{
    void Start()
    {
        Button button = GetComponent<Button>();

        button.onClick.AddListener(SoundClick);
        //button.OnPointerEnter.AddListener(SoundClick);
        //button.onClick.AddListener(SoundMouseOver);
    }

    void SoundClick()
    {
        AudioController.Instance.PlaySFX(2);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioController.Instance.PlaySFX(3);
    }
}
