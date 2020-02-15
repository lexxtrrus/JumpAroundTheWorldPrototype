using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleCounter : MonoBehaviour
{
    [SerializeField] private Text _obstacleCountText;
    private int _obstacleCount = 0;

    private void Awake() 
    {
        _obstacleCountText.text = _obstacleCount.ToString();
    }

    public void AddObstacle()
    {
        _obstacleCount++;
        _obstacleCountText.text = _obstacleCount.ToString();
    }

    public void RemoveObstacle()
    {
        _obstacleCount--;
        _obstacleCountText.text = _obstacleCount.ToString();
    }
}
