using UnityEngine;

public class EnemyWithChase : EnemyPatrol
{
    [SerializeField] private float _chaseSpeed;
    [SerializeField] private float _chaseRange;
    [SerializeField] private Transform _player;

    private bool _isSeePlayer;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        if (EnemyAreaView.IsSeePlayer)
        {
            ChasePlayer();
        }
        else
        {
            base.FlipEnemy();
            base.Update();
        }
    }

    private void ChasePlayer()
    {
        float direction = (_player.position.x > transform.position.x) ? 1f : -1f;
        base.m_spriteRenderer.flipX = (direction < 0);

        transform.position = Vector2.MoveTowards(transform.position, _player.position, _chaseSpeed * Time.deltaTime);
    }
}
