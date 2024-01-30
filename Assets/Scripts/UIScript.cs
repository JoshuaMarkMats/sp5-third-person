using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    private int ammoCount = 0;
    [SerializeField]
    private TextMeshProUGUI ammoCounterText;

    public void AddAmmo()
    {
        ammoCount++;
        ammoCounterText.text = $" Ammo: {ammoCount}";
    }
}
