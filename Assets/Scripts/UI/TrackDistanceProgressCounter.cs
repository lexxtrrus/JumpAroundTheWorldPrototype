using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TrackDistanceProgressCounter : MonoBehaviour
{
    [SerializeField] Transform _planet;
    [SerializeField] Transform _player;
    [SerializeField] private Text _distanceCounterText;
    [SerializeField] private RectTransform _worldImage;  
    private int _totalDegrees = 0;
    
    private void FixedUpdate() 
    {
        if(_player.position.y > 0 && _player.position.z >= 0)
        {
            Quaternion rot = CalculateRotation(_planet.up, _player.up);
            _worldImage.rotation = Quaternion.Euler(0f, 0f, rot.eulerAngles.z);
            _totalDegrees = Mathf.RoundToInt((rot.eulerAngles.z * 100f) / 360f);
            _distanceCounterText.text = $"{_totalDegrees.ToString()}%";
            return;
        }
        else if(_player.position.y <= 0 && _player.position.z > 0)
        {
            Quaternion rot = CalculateRotation(_planet.forward, _player.up);
            _worldImage.rotation = Quaternion.Euler(0f, 0f, 90f + rot.eulerAngles.z);
            _totalDegrees = Mathf.RoundToInt((rot.eulerAngles.z + 90f) * 100f / 360f);
            _distanceCounterText.text = $"{_totalDegrees.ToString()}%";
            return;
        }
        else if(_player.position.y <= 0 && _player.position.z <= 0)
        {
            Quaternion rot = CalculateRotation(-1f * _planet.up, _player.up);
            _worldImage.rotation = Quaternion.Euler(0f, 0f, 180f + rot.eulerAngles.z);
            _totalDegrees = Mathf.RoundToInt((rot.eulerAngles.z + 180f) * 100f / 360f);
            _distanceCounterText.text = $"{_totalDegrees.ToString()}%";
            return;
        }
        else if(_player.position.y >= 0 && _player.position.z < 0)
        {
            Quaternion rot = CalculateRotation(-1f * _planet.forward, _player.up);
            _worldImage.rotation = Quaternion.Euler(0f, 0f, 270f + rot.eulerAngles.z);
            _totalDegrees = Mathf.RoundToInt((rot.eulerAngles.z + 270f) * 100f / 360f);
            _distanceCounterText.text = $"{_totalDegrees.ToString()}%";
            return;
        }
        
        
    }

    private Quaternion CalculateRotation(Vector3 from, Vector3 to)
    {
        Quaternion rot = Quaternion.FromToRotation(from, to);
        rot.z = rot.x;
        rot.x = 0f;
        return rot;
    }
}
