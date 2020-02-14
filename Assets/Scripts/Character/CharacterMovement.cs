using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{    
    [SerializeField] private GameObject _planet;
    [SerializeField] private Transform _characterGraphics;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private InputController _inputController;

    private Rigidbody _rig;
    private float _distanceToGround = 0f;
    private Vector3 _normalizedToGround;
    private RaycastHit hit;
    private bool _isOnGround;

    private void Reset() 
    {
        _rig = GetComponent<Rigidbody>();
        _rig.freezeRotation = true;
        _rig.useGravity = false;
        _inputController = FindObjectOfType<InputController>();

    }
    private void Update() 
    {
        //движение по оси X, двигаю графику
        float x = _characterGraphics.localPosition.x;  
        x = Mathf.Lerp(_characterGraphics.localPosition.x, _inputController.Strafe, Time.deltaTime * 5f);
        x = Mathf.Clamp(x, -5.5f, 5.5f);

        var pos = _characterGraphics.localPosition;
        pos.x = x;
        _characterGraphics.localPosition = pos;

        //движение вперёд по собственной оси Z, двигается Root Gameobjet
        float z = Time.deltaTime * _speed; 
        transform.Translate(0f, 0f, z);

        //имитация гравитации и вращение root, что бы его vector.up был нормализован относительно поверхности коллайдера
        if (Physics.Raycast(transform.position, -transform.up, out hit, 5f)) 
        { 
            _distanceToGround = hit.distance;
            _normalizedToGround = hit.normal;
            Debug.DrawRay(transform.position, -transform.up, Color.red, 1f);
        }

        Quaternion toRotation = Quaternion.FromToRotation(transform.up, _normalizedToGround) * transform.rotation;        
        transform.rotation = toRotation;
    }
}
