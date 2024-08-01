using UnityEngine;
using UnityEngine.Events;

public abstract class AliveGamingObject : MonoBehaviour
{
    [SerializeField] protected int _maxHealth;
    protected int _currentHealth;

    public event UnityAction ChangeHealth;

    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;

    private int _damage = 1;

    protected virtual void Start()
    {
        _currentHealth = _maxHealth;
    }

    public virtual void TakeDamage()
    {
        _currentHealth -= _damage;

        if (_currentHealth > 0)
            OnChangeHealth();
        else
            OnDeath();
    }

    protected abstract void OnDeath();

    protected void OnChangeHealth()
    {
        ChangeHealth?.Invoke();
    }
}
