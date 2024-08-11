using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class VampirismAbility : MonoBehaviour
{
    [SerializeField] private Collider2D _activeZone;
    [SerializeField] private float _healTime = 6f;
    [SerializeField] private float _reloadTime = 6f;
    [SerializeField] private KeyCode _activateAbility = KeyCode.G;
    [SerializeField] private AbilityUI _abilityUI;

    private Enemy _currentEnemy;
    private Coroutine _currentCoroutine;
    private bool _isActive;
    private bool _isEnemyInRange = true;

    public UnityAction OnHealStart;

    private void Update()
    {
        if (Input.GetKeyDown(_activateAbility) && !_isActive && _isEnemyInRange)
        {
            ActivateAbility();
        }
    }

    private void ActivateAbility()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(HandleVampirism());
    }

    private IEnumerator HandleVampirism()
    {
        _isActive = true;
        float spendTime = 1f;
        float remainingTime = _healTime;

        _abilityUI.UpdateTimerDisplay(_healTime);

        while (remainingTime > 0 && _currentEnemy != null)
        {
            yield return new WaitForSeconds(spendTime);

            if (_currentEnemy != null)
            {
                _currentEnemy.TakeDamage();
                remainingTime -= spendTime;
                OnHealStart?.Invoke();

                _abilityUI.UpdateTimerDisplay(remainingTime);
            }
        }

        _isActive = false;
        _currentCoroutine = StartCoroutine(HandleReload());
    }

    private IEnumerator HandleReload()
    {
        float elapsedTime = 0f;
        float reloadDuration = _reloadTime;

        while (elapsedTime < reloadDuration)
        {
            elapsedTime += Time.deltaTime;

            float currentValue = Mathf.Lerp(0, reloadDuration, elapsedTime / reloadDuration);
            _abilityUI.UpdateTimerDisplay(currentValue);

            yield return null;
        }

        _abilityUI.UpdateTimerDisplay(reloadDuration);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _currentEnemy = enemy;
            _isEnemyInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy _))
        {
            _currentEnemy = null;
            _isEnemyInRange = false;

            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
                _isActive = false;
                _currentCoroutine = StartCoroutine(HandleReload());
            }
        }
    }
}
