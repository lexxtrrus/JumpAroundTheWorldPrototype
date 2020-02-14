using UnityEngine;

public class CharacterJump : MonoBehaviour 
{
    [SerializeField] private AnimationCurve _jumpCurve;    
    [SerializeField] private float _startY = 0.5f;
    [SerializeField] private float _jumpHeight = 5f;
    [SerializeField] private float _speedJump = 1f;
    private float _iteration = 0f;

    private void Update() 
    {
        var pos = transform.localPosition;
        pos.y = _startY + _jumpCurve.Evaluate(_iteration) * _jumpHeight;

        transform.localPosition = pos;
        _iteration += Time.deltaTime * _speedJump;

        if(_iteration < 1f) return;
        _iteration = 0f;
    }
    
}