using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class OnDeathStatisticScreen : MonoBehaviour
{
    [SerializeField] private TimeCounter _timeCounter;
    [SerializeField] private GameObject _panel;
    [SerializeField] private Text _secondsText;
    [SerializeField] private Text _ObstaclesText;

    public static Action OnDieAction;
    public static Action OnCountObstaclesChanged;
    public static Action OnTotalSecondsChanged;

    private int _obstacles = 0;
    private int _seconds = 0;

    private void Awake() 
    {
        OnDieAction += ShowDeathPanel;
        OnCountObstaclesChanged += AddObstacleCount; 
    }    

    private void OnDestroy() 
    {
        OnDieAction -= ShowDeathPanel;
        OnCountObstaclesChanged -= AddObstacleCount;   
    }

    private void ShowDeathPanel()
    {
        _panel.SetActive(true);
        _secondsText.text = _timeCounter.TotalSeconds.ToString();
        _ObstaclesText.text = _obstacles.ToString();
    }

    private void AddObstacleCount()
    {
        _obstacles++;
    }
}
