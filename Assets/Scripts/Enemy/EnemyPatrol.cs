using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _patrolPoints;

    protected Transform _currentTarget;
    protected SpriteRenderer _spriteRenderer;
    private int _currentPatrolIndex = 0;

    protected virtual void Start()
    {
        if (_patrolPoints.Length > 0)
            _currentTarget = _patrolPoints[0];

        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void Update()
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

    protected void FlipEnemy()
    {
        _spriteRenderer.flipX = _currentPatrolIndex < _patrolPoints.Length - 1;
    }
}
