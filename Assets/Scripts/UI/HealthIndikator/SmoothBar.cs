using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SmoothBar : HealthDisplay
{
    [SerializeField] private Image _bar;
    [SerializeField] private float _smoothSpeed = 0.1f;

    private Coroutine _currentCoroutine;

    private void Awake()
    {
        if (_bar == null)
        {
            _bar = GetComponent<Image>();
        }
    }

    protected override void UpdateDisplay()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(SmoothSetHealth());
    }

    private IEnumerator SmoothSetHealth()
    {
        float targetFillAmount = (float)_player.CurrentHealth / _player.MaxHealth;
        float initialFillAmount = _bar.fillAmount;
        float elapsedTime = 0f;

        while (elapsedTime < _smoothSpeed)
        {
            elapsedTime += Time.deltaTime;
            _bar.fillAmount = Mathf.Lerp(initialFillAmount, targetFillAmount, elapsedTime / _smoothSpeed);
            yield return null;
        }

        _bar.fillAmount = targetFillAmount;
    }
}
