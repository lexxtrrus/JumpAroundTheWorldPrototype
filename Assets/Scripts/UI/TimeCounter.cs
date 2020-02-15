using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] Text _timeCounter;
    private float _startTime;    
    private float _helpCountTime;

    private float _totalSeconds;
    public float TotalSeconds => _totalSeconds;

    private void Awake() 
    {
        _startTime = Time.time;
        _helpCountTime = Time.time;
        ObstacleCollisionChecker.OnStartReached += CircleComplete;
    }

    private void OnDestroy() 
    {
        ObstacleCollisionChecker.OnStartReached += CircleComplete;
    }

    private void Update() 
    {
        var curCircle =  Mathf.RoundToInt(Time.time - _helpCountTime);
        _timeCounter.text = curCircle.ToString();
        _totalSeconds = Mathf.RoundToInt(Time.time - _startTime);
    }

    private void CircleComplete()
    {
        _helpCountTime = Time.time;
    }


}
