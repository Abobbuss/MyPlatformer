using UnityEngine;
using UnityEngine.UI;

public class SliderBar : HealthDisplay
{
    [SerializeField] private Slider _slider;

    protected override void UpdateDisplay()
    {
        _slider.value = (float)m_aliveObject.CurrentHealth / m_aliveObject.MaxHealth;
    }
}
