using UnityEngine;
using UnityEngine.UI;
public class PauseButtonPressed : MonoBehaviour 
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private GameObject _panel;

    private void Awake() 
    {
        _pauseButton.onClick.AddListener(Pause);
        OnDeathStatisticScreen.OnDieAction += StopTouchingPauseButton;
    }

    private void OnDestroy() 
    {
        OnDeathStatisticScreen.OnDieAction -= StopTouchingPauseButton;
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        _panel.SetActive(true);
    }

    private void StopTouchingPauseButton()
    {
        _pauseButton.interactable = false;
        Time.timeScale = 0f;
    }
}