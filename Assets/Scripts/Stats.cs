using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour
{
    public static Stats Instance { get; private set; }

    public int ChineseTakeout = 0;

    public UnityEvent StatsUpdatedEvent;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void AddChineseTakeout()
    {
        ChineseTakeout++;
        StatsUpdatedEvent.Invoke();
    }
}
