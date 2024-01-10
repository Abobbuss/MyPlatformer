using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _patrolPoints;

    private Transform _currentTarget;
    private SpriteRenderer _spriteRenderer;
    private int _currentPatrolIndex = 0;

    private void Start()
    {
        if (_patrolPoints.Length > 0)
            _currentTarget = _patrolPoints[0];

        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float distanceSwitch = 0.25f;

        if (_currentTarget != null)
            transform.position = Vector2.MoveTowards(transform.position, _currentTarget.position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _currentTarget.position) < distanceSwitch)
        {
            SwitchTarget();
            FlipEnemy();
        }
    }

    private void SwitchTarget()
    {
        _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Length;
        _currentTarget = _patrolPoints[_currentPatrolIndex];
    }

    private void FlipEnemy()
    {
        _spriteRenderer.flipX = _currentPatrolIndex < _patrolPoints.Length - 1;
    }
}
