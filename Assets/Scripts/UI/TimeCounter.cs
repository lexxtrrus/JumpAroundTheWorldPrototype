using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] Text _timeCounter;
    private float _startTime;

    private void Awake() 
    {
        _startTime = Time.time;
        ObstacleCollisionChecker.OnStartReached += CircleComplete;
    }

    private void OnDestroy() 
    {
        ObstacleCollisionChecker.OnStartReached += CircleComplete;
    }

    private void Update() 
    {
        _timeCounter.text = Mathf.RoundToInt(Time.time - _startTime).ToString();
    }

    private void CircleComplete()
    {
        _startTime = Time.time;
    }
}
