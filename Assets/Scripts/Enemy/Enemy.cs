using UnityEngine;

public class Enemy : AliveGamingObject
{
    protected override void OnDeath()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy _))
        {
            TakeDamage();
            OnChangeHealth();
        }
    }
}
