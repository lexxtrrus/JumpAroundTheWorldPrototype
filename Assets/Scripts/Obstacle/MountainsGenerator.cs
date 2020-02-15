using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MountainsGenerator : MonoBehaviour
{
    [SerializeField] private Transform _playerPos; // необходимо для определения ближайшего obstacle в _generatedMountains к player 
    [SerializeField] private List<GameObject> _prefabs = new List<GameObject>();
    [SerializeField] private List<GameObject> _generatedMountains =new List<GameObject>();
    [SerializeField] private GameObject _obstaclesPlaced;
    [SerializeField] private ObstacleCounter _obstacleCounter;
    private Coroutine _delayPlacement;
    private bool _isChecking = false;
    private float _distanceToCurrentObsctacle;
    private float _distanceToForwardObstacle;

    public static Action<Transform> OnGenerateMountine;
    public static Action OnStartCheck;

    private void Awake() 
    {
        OnGenerateMountine += GenerateMountine;
        ObstacleCollisionChecker.OnStartReached += StartChecking;
        ObstacleCollisionChecker.OnStartReached += HidePlacedObstacle;
    }

    private void OnDestroy() 
    {
        OnGenerateMountine -= GenerateMountine;
        ObstacleCollisionChecker.OnStartReached -= StartChecking;
        ObstacleCollisionChecker.OnStartReached -= HidePlacedObstacle;
    }
    private void GenerateMountine(Transform pos)
    {  
        StartCoroutine(PlacementObstacle(pos));
    }

    private void Update() 
    {
        if(!_isChecking) return;

        _distanceToCurrentObsctacle = Vector3.Distance(_playerPos.position, _generatedMountains[0].transform.position);
        if(_generatedMountains[1] != null)
        {
            _distanceToForwardObstacle = Vector3.Distance(_playerPos.position, _generatedMountains[1].transform.position);
        } 

        if(_distanceToForwardObstacle < _distanceToCurrentObsctacle)
        {
            StartCoroutine(DestroyObstacle(_generatedMountains[0]));            
            
            if(_generatedMountains[0]!= null) 
            {
                _generatedMountains.RemoveAt(0);
                //_obstacleCounter.RemoveObstacle();
            }
        }
    }

    private IEnumerator PlacementObstacle(Transform pos)
    {
        int rand = UnityEngine.Random.Range(0, _prefabs.Count);
        Vector3 tempPosition = pos.transform.position;
        Quaternion tempRotation = pos.rotation;

        yield return new WaitForSeconds(1.5f);

        var mountine = Instantiate(_prefabs[rand], tempPosition, tempRotation);
        _generatedMountains.Add(mountine);
        mountine.transform.position -= mountine.transform.up *  0.2f;
        mountine.transform.SetParent(transform);
        _obstacleCounter.AddObstacle();
        OnDeathStatisticScreen.OnCountObstaclesChanged?.Invoke();
    }

    private void StartChecking()
    {
        _isChecking = true;
    }

    private IEnumerator DestroyObstacle(GameObject go)
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(go);
    }

    private void HidePlacedObstacle()
    {
        _obstaclesPlaced.SetActive(false);
    }
}
