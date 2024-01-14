using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathZone : MonoBehaviour
{
    public void KillEnemy()
    {
        transform.parent.GetComponent<Enemy>().TakeDamage();
    }
}
