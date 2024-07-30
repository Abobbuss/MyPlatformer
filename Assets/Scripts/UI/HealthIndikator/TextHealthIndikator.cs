using TMPro;
using UnityEngine;

public class TextHealthIndikator : HealthDisplay
{
    [SerializeField] private TextMeshProUGUI _health;

    protected override void UpdateDisplay()
    {
        _health.text = $"{_player.CurrentHealth} / {_player.MaxHealth}";
    }
}
