using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAreaView : MonoBehaviour
{
    private static bool _isSeePlayer;

    public static bool IsSeePlayer => _isSeePlayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player _))
        {
            _isSeePlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player _))
        {
            _isSeePlayer = false;
        }
    }
}
