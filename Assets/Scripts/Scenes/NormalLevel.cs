using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NormalLevel : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _itemsToPickup;

    private void Start()
    {
        AudioController.Instance.SetBackgroundMusic(0);
    }

    private void Update()
    {
        for (int i = _itemsToPickup.Count -1;  i >= 0; i--)
        {
            if (_itemsToPickup[i] == null)
                _itemsToPickup.RemoveAt(i);
        }

        if (_itemsToPickup.Count <= 0)
        {
            SceneLoader.LoadScene("RedLevel");
        }
            
    }
}
