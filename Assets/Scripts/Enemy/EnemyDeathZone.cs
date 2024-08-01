using UnityEngine;

public class EnemyDeathZone : MonoBehaviour
{
    public void KillEnemy()
    {
        transform.parent.GetComponent<Enemy>().TakeDamage();
    }
}
