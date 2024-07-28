using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;

    private void Start()
    {
        UpdateHealthBar();
    }

    private void OnEnable()
    {
        _player.ChangeHealth += OnChangeHealth;
    }

    private void OnDisable()
    {
        _player.ChangeHealth -= OnChangeHealth;
    }

    private void OnChangeHealth()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        _slider.value = (float)_player.CurrentHealth / _player.MaxHealth;
    }
}
