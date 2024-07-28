using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;

    public event UnityAction TakingDamage;
    public event UnityAction ChangeHealth;

    private int _currentHealth;

    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage()
    {
        _currentHealth -= 1;

        if (_currentHealth > 0)
        {
            TakingDamage?.Invoke();
            ChangeHealth?.Invoke();
        }
        else
        {
            Debug.Log("Game over");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out EnemyDeathZone deathZone))
        {
            deathZone.KillEnemy();
        }
        else if (other.TryGetComponent(out Enemy _))
        {
            TakeDamage();
        }
    }

    private void OnEnable()
    {
        Medkit.TakingMedKit += Healing;
    }

    private void OnDisable()
    {
        Medkit.TakingMedKit -= Healing;
    }

    private void Healing()
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth += 1;
            ChangeHealth?.Invoke();
        } 
    }
}
