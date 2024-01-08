using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _target1;
    [SerializeField] private Transform _target2;

    private Transform _currentTarget;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _currentTarget = _target1;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_currentTarget != null)
            transform.position = Vector2.MoveTowards(transform.position, _currentTarget.position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _currentTarget.position) < 0.25f)
        {
            SwitchTarget(_currentTarget);
            FlipEnemy(_currentTarget);
        }
    }

    private void SwitchTarget(Transform currentTarget)
    {
        if (currentTarget == _target1)
            _currentTarget = _target2;
        else
            _currentTarget = _target1;
    }

    private void FlipEnemy(Transform currentTarget)
    {
        if (currentTarget == _target1)
            _spriteRenderer.flipX = false;
        else
            _spriteRenderer.flipX = true;
    }
}
