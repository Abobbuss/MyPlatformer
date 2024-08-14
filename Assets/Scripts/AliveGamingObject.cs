using UnityEngine;
using UnityEngine.Events;

public abstract class AliveGamingObject : MonoBehaviour
{
    [SerializeField] protected int m_maxHealth;
    protected int m_currentHealth;

    public event UnityAction ChangeHealth;

    public int CurrentHealth => m_currentHealth;
    public int MaxHealth => m_maxHealth;

    private int _damage = 1;

    protected virtual void Start()
    {
        m_currentHealth = m_maxHealth;
    }

    public virtual void TakeDamage()
    {
        m_currentHealth -= _damage;

        if (m_currentHealth > 0)
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
