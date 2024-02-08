using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour
{   
    [SerializeField]
    private string _label = "Chinese Takeout Retrieved";
    [SerializeField]
    private TextMeshProUGUI _chineseTakeoutCounterText;

    private void Start()
    {
        _chineseTakeoutCounterText.text = $"{_label}: {Stats.Instance.ChineseTakeout}";
    }

    public void AddChineseTakeout()
    {
        Stats.Instance.ChineseTakeout++;
        _chineseTakeoutCounterText.text = $"{_label}: {Stats.Instance.ChineseTakeout}";
    }
}
