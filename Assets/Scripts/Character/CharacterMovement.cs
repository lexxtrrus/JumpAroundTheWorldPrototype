using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{    
    [Header("Ссылки на необходимые обьекты")]
    [SerializeField] private GameObject _planet;
    [SerializeField] private InputController _inputController;
    [SerializeField] private Transform _cameraHolder;

    [Header("Скорость игрока")]
    [SerializeField] private float _speed = 1f;

    private float _distanceToGround = 0f;
    private Vector3 _normalizedToGround;
    private RaycastHit hit;
    private bool _isOnGround;

    private void Reset() 
    {        
        _inputController = FindObjectOfType<InputController>();
        _cameraHolder = Camera.main.transform;
    }
    private void Update() 
    {
        //движение по оси X, двигаю root
        float x = transform.position.x;  
        x = Mathf.Lerp(transform.position.x, _inputController.Strafe, Time.deltaTime * 1f);
        x = Mathf.Clamp(x, -0.65f, 0.65f);

        var pos = transform.position;
        pos.x = x;
        transform.position = pos;

        //движение вперёд по собственной оси Z, двигается Root Gameobjet и Camera Holder
        float z = Time.deltaTime * _speed; 
        transform.Translate(0f, 0f, z);
        _cameraHolder.Translate(0f, 0f, z);

        //имитация гравитации для root, вращение root и camera holder, что бы его vector.up был нормализован относительно поверхности коллайдера
        if (Physics.Raycast(transform.position, -transform.up, out hit, 5f)) 
        { 
            _distanceToGround = hit.distance;
            _normalizedToGround = hit.normal;
            Debug.DrawRay(transform.position, -transform.up, Color.red, 1f);
        }

        Quaternion toRotation = Quaternion.FromToRotation(transform.up, _normalizedToGround) * transform.rotation;        
        transform.rotation = toRotation;

        var temprot = toRotation;
        temprot.y = 0f;
        temprot.z = 0f;
        _cameraHolder.rotation = temprot;
    }
}
