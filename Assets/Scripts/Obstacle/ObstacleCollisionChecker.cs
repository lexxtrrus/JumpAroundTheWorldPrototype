using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObstacleCollisionChecker : MonoBehaviour
{
    public static event Action OnStartReached;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.transform.parent.gameObject.CompareTag("Respawn"))
        {
            OnDeathStatisticScreen.OnDieAction?.Invoke();
        }

        if(other.gameObject.CompareTag("Finish"))
        {
            OnStartReached?.Invoke();
        }
    }
}
