using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasScaler))]
public class CanvasScaleHandler : MonoBehaviour
{
    public static CanvasScaleHandler Instance { get; private set; }

    private CanvasScaler _scaler;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _scaler = GetComponent<CanvasScaler>();
        }
            
        else
            Destroy(gameObject);

        //PlayerPrefs.SetInt(VideoSettings.UI_SCALE, 4);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetScale(PlayerPrefs.GetInt(VideoSettings.UI_SCALE , 4));
    }

    public void SetScale(int scale)
    {
        _scaler.scaleFactor = Mathf.Clamp((float)scale, 1, 4) / 4;
    }
}
