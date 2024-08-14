using UnityEngine;

public abstract class HealthDisplay : MonoBehaviour
{
    [SerializeField] protected AliveGamingObject m_aliveObject;

    protected virtual void Start()
    {
        UpdateDisplay();
    }

    protected virtual void OnEnable()
    {
        m_aliveObject.ChangeHealth += OnChangeHealth;
    }

    protected virtual void OnDisable()
    {
        m_aliveObject.ChangeHealth -= OnChangeHealth;
    }

    private void OnChangeHealth()
    {
        UpdateDisplay();
    }

    protected abstract void UpdateDisplay();
}
