using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _patrolPoints;

    protected Transform m_currentTarget;
    protected SpriteRenderer m_spriteRenderer;
    private int _currentPatrolIndex = 0;

    protected virtual void Start()
    {
        if (_patrolPoints.Length > 0)
            m_currentTarget = _patrolPoints[0];

        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void Update()
    {
        float distanceSwitch = 0.25f;

        if (m_currentTarget != null)
            transform.position = Vector2.MoveTowards(transform.position, m_currentTarget.position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, m_currentTarget.position) < distanceSwitch)
        {
            SwitchTarget();
            FlipEnemy();
        }
    }

    private void SwitchTarget()
    {
        _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Length;
        m_currentTarget = _patrolPoints[_currentPatrolIndex];
    }

    protected void FlipEnemy()
    {
        m_spriteRenderer.flipX = _currentPatrolIndex < _patrolPoints.Length - 1;
    }
}
