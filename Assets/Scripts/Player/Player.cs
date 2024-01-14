using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;

    public static event UnityAction<Player> TakingDamage;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage()
    {
        _currentHealth -= 1;

        if (_currentHealth > 0)
        {
            TakingDamage?.Invoke(this);
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
        }
    }
}
