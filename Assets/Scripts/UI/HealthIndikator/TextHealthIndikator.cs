using TMPro;
using UnityEngine;

public class TextHealthIndikator : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _health;

    private void Start()
    {
        SetHealth();
    }

    private void OnEnable()
    {
        _player.ChangeHealth += SetHealth;
    }

    private void OnDisable()
    {
        _player.ChangeHealth -= SetHealth;
    }

    private void SetHealth()
    {
        _health.text = $"{_player.CurrentHealth} / {_player.MaxHealth}";
    }
}
