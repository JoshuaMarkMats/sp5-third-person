using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;

    [SerializeField]
    private List<GameObject> _itemsToPickup;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        AudioController.Instance.SetBackgroundMusic(0);
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        for (int i = _itemsToPickup.Count -1;  i >= 0; i--)
        {
            if (_itemsToPickup[i] == null)
                _itemsToPickup.RemoveAt(i);
        }

        
            
    }

    public void NextScene()
    {
        Debug.Log("Attempting to exit scene");

        if (_itemsToPickup.Count <= 0)
        {
            SceneLoader.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
