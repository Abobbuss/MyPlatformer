using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class VampirismAbility : MonoBehaviour
{
    [SerializeField] private Collider2D _activeZone;
    [SerializeField] private float _healTime = 6f;
    [SerializeField] private float _reloadTime = 6f;
    [SerializeField] private KeyCode _activateAbility = KeyCode.G;

    private Enemy _currentEnemy;
    private Coroutine _currentCoroutine;
    private WaitForSeconds _waitTime = new WaitForSeconds(1f);
    private bool _isActive;
    private bool _isEnemyInRange = false;
    private float _currentTimeAbility;

    public float CurrentTimeAbility { get; private set; }
    public int DamageDealtToEnemy { get; private set; }

    public event UnityAction HealingCompleted;
    public event UnityAction ReloadingCompleted;

    private void Start()
    {
        _currentTimeAbility = _healTime;
    }

    private void Update()
    {
        if (Input.GetKeyDown(_activateAbility) && !_isActive && _isEnemyInRange)
            ActivateAbility();
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

        while (_currentTimeAbility > 0 && _currentEnemy != null)
        {
            yield return _waitTime;

            if (_currentEnemy != null)
            {
                _currentEnemy.TakeDamage();
                _currentTimeAbility -= spendTime;
                HealingCompleted?.Invoke();
            }
        }

        _isActive = false;
        _currentCoroutine = StartCoroutine(HandleReload());
    }

    private IEnumerator HandleReload()
    {
        while (_currentTimeAbility < _reloadTime)
        {
            _currentTimeAbility = Mathf.Lerp(0, _reloadTime, _currentTimeAbility / _reloadTime) + Time.deltaTime;
            ReloadingCompleted?.Invoke();

            yield return null;
        }
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
