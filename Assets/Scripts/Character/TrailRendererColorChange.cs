using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRendererColorChange : MonoBehaviour
{
    [SerializeField] private TrailRenderer _trail;

    private Gradient _gradient;
    private GradientColorKey[] _colorKey;
    private GradientAlphaKey[] _alphaKey;


    private void Awake() 
    {        
        ObstacleCollisionChecker.OnStartReached += ChangeColor;
        _gradient = new Gradient();
        _colorKey = new GradientColorKey[2];
        _colorKey[0].time = 0f;
        _colorKey[1].time = 1f;
        _alphaKey = new GradientAlphaKey[2];
        _alphaKey[0].alpha = 1f;
        _alphaKey[0].time = 0f;
        _alphaKey[1].alpha = 1f;
        _alphaKey[1].time = 1f;
    }

    private void OnDestroy() 
    {
        ObstacleCollisionChecker.OnStartReached -= ChangeColor;
    }
    
    private void ChangeColor()
    {
        Color rand = Color.black;
        while(rand.r + rand.g + rand.b < 1.0f)
        {
            rand = new Color(Random.value, Random.value, Random.value);
        }

        _colorKey[0].color = rand;

        rand = Color.black;

        while(rand.r + rand.g + rand.b < 1.0f)
        {
            rand = new Color(Random.value, Random.value, Random.value);
        }

        _colorKey[1].color = rand;

        _gradient.SetKeys(_colorKey, _alphaKey);

        _trail.colorGradient = _gradient;
    }
}
