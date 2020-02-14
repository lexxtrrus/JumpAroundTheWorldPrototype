using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollisionChecker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.transform.parent.gameObject.CompareTag("Respawn"))
        {
            Debug.Log("Yep");
        }

        if(other.gameObject.CompareTag("Finish"))
        {
            MountainsGenerator.OnStartCheck?.Invoke();
            Debug.Log("StartChecking");
        }
    }
}
