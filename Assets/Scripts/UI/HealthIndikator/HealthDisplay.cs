using UnityEngine;

public abstract class HealthDisplay : MonoBehaviour
{
    [SerializeField] protected AliveGamingObject _aliveObject;

    protected virtual void Start()
    {
        UpdateDisplay();
    }

    protected virtual void OnEnable()
    {
        _aliveObject.ChangeHealth += OnChangeHealth;
    }

    protected virtual void OnDisable()
    {
        _aliveObject.ChangeHealth -= OnChangeHealth;
    }

    private void OnChangeHealth()
    {
        UpdateDisplay();
    }

    protected abstract void UpdateDisplay();
}
