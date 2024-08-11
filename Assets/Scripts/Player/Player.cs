using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : AliveGamingObject
{
    [SerializeField] private float _invincibilityDuration = 2f;

    public event UnityAction TakingDamage;

    private bool _canTakeDamage = true;

    private void OnEnable()
    {
        Medkit.TakingMedKit += HealingAllHealth;
    }

    private void OnDisable()
    {
        Medkit.TakingMedKit -= HealingAllHealth;
    }

    private void Start()
    {
        _currentHealth = 5;
    }

    public void Heal(int value)
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth += value;
            OnChangeHealth();
        }
    }

    private void HealingAllHealth()
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth = _maxHealth;
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
    }

    protected override void OnDeath()
    {
        Debug.Log("Game over");
        Destroy(gameObject);
    }
}
