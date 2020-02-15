using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private float _screenCenter;
    private float _inputBoard;
    private float _strafe = 0f;
    public float Strafe
    {
        get => _strafe;
        set => _strafe = value;
    } 

    private void Awake() 
    {
        _screenCenter = Screen.width * 0.5f;
        _inputBoard = Screen.height * 0.7f;
    }

    private void Update() 
    {
        float x = 0f;        

        if(Input.GetMouseButton(0) && Input.mousePosition.y < _inputBoard) 
        {
            x = Input.mousePosition.x;

            if (x > _screenCenter)
            {
                _strafe = 10 * (x - _screenCenter) / _screenCenter; 
                //приходится умножать на 10 из-за масштаба Gameobjet character = 0.1f
            }
            else
            {
                _strafe = 1f - x / _screenCenter;
                _strafe *= -10f;
            }
        }  
    } 
}
