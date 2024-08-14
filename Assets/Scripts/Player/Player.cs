using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : AliveGamingObject
{
    [SerializeField] private float _invincibilityDuration = 2f;

    private bool _canTakeDamage = true;

    public void TakeHeal(int value)
    {
        if (m_currentHealth < m_maxHealth)
        {
            m_currentHealth += value;
            OnChangeHealth();
        }
    }

    public void HealAllHealth()
    {
        if (m_currentHealth < m_maxHealth)
        {
            m_currentHealth = m_maxHealth;
            OnChangeHealth();
        } 
    }

    private IEnumerator InvincibilityCoroutine()
    {
        _canTakeDamage = false;
        yield return new WaitForSeconds(_invincibilityDuration);

        _canTakeDamage = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out EnemyDeathZone deathZone))
        {
            deathZone.KillEnemy();
        }
        else if (other.TryGetComponent(out Enemy _) && _canTakeDamage)
        {
            TakeDamage();
            StartCoroutine(InvincibilityCoroutine());
        }
        else if (other.TryGetComponent(out Medkit medkit)) 
        {
            HealAllHealth();
        }
    }

    protected override void OnDeath()
    {
        Debug.Log("Game over");
        Destroy(gameObject);
    }
}
