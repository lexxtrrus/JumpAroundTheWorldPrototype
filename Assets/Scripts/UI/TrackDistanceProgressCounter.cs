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
    
    private void LateUpdate() 
    {
        Quaternion rot = Quaternion.FromToRotation(_planet.up, _player.up);
        rot.z = rot.x;
        rot.x = 0f;
        _worldImage.rotation = Quaternion.Euler(0f, 0f, rot.eulerAngles.z); 
        _totalDegrees = Mathf.RoundToInt((rot.eulerAngles.z * 100f) / 360f);
        _distanceCounterText.text = $"{_totalDegrees.ToString()}%";
        //Debug.Log(rot.eulerAngles.z);
    }
}
