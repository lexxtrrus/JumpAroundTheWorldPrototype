using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnBackToGameButtonPressed : MonoBehaviour
{   
    [SerializeField] private Button _pauseButton;
    [SerializeField] private GameObject _panel;

    private void OnEnable() 
    {
        _pauseButton.onClick.AddListener(BackToGame);
    }

    private void BackToGame()
    {
        Time.timeScale = 1f;
        _panel.SetActive(false);
    }
}
