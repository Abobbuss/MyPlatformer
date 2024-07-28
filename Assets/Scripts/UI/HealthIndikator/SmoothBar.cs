using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SmoothBar : MonoBehaviour
{
    [SerializeField] private Image _bar;
    [SerializeField] private Player _player;
    [SerializeField] private float _smoothSpeed = 0.1f;

    private Coroutine _currentCoroutine;

    private void Awake()
    {
        if (_bar == null)
        {
            _bar = GetComponent<Image>();
        }
    }

    private void Start()
    {
        SetHealth();
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

    private void SetHealth()
    {
        _bar.fillAmount = (float)_player.CurrentHealth / _player.MaxHealth;
    }
}
