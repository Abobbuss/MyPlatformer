using UnityEngine;
using UnityEngine.UI;

public class SliderBar : HealthDisplay
{
    [SerializeField] private Slider _slider;

    protected override void UpdateDisplay()
    {
        _slider.value = (float)_player.CurrentHealth / _player.MaxHealth;
    }
}
