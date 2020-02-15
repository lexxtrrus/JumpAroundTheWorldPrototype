using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    [SerializeField] private Button _loadButton;

    private void Awake() 
    {
        _loadButton.onClick.AddListener(LoadScene);
    }

    private void LoadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}