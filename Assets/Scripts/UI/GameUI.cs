using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private string _label = "Chinese Takeout Retrieved";
    [SerializeField]
    private TextMeshProUGUI _chineseTakeoutCounterText;

    private void Start()
    {
        UpdateUI();

        Stats.Instance.StatsUpdatedEvent.AddListener(UpdateUI);
    }

    public void UpdateUI()
    {
        _chineseTakeoutCounterText.text = $"{_label}: {Stats.Instance.ChineseTakeout}";
    }
}
