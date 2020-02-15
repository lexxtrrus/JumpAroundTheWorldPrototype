using UnityEngine;
using UnityEngine.UI;
public class PauseButtonPressed : MonoBehaviour 
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private GameObject _panel;

    private void Awake() 
    {
        _pauseButton.onClick.AddListener(Pause);
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        _panel.SetActive(true);
    }
}