using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedLevel : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _itemsToPickup;

    private void Start()
    {
        AudioController.Instance.SetBackgroundMusic(1);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        for (int i = _itemsToPickup.Count - 1; i >= 0; i--)
        {
            if (_itemsToPickup[i] == null)
                _itemsToPickup.RemoveAt(i);
        }

        if (_itemsToPickup.Count <= 0)
        {
            SceneLoader.LoadScene("Playground");
        }
            
    }
}
