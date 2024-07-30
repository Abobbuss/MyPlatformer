using UnityEngine;

public abstract class HealthDisplay : MonoBehaviour
{
    [SerializeField] protected Player _player;

    protected virtual void Start()
    {
        UpdateDisplay();
    }

    protected virtual void OnEnable()
    {
        _player.ChangeHealth += OnChangeHealth;
    }

    protected virtual void OnDisable()
    {
        _player.ChangeHealth -= OnChangeHealth;
    }

    private void OnChangeHealth()
    {
        UpdateDisplay();
    }

    protected abstract void UpdateDisplay();
}
