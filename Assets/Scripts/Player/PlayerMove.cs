using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Animator _animator;

    private SpriteRenderer _spriteRenderer;
    private string _horizontalInput = "Horizontal";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float horizontalMove = Input.GetAxis(_horizontalInput);

        MovePlayer(horizontalMove);

        if (horizontalMove != 0)
            FlipCharacter(horizontalMove);
    }

    private void MovePlayer(float horizontalInput)
    {
        Vector2 movement = new Vector2(horizontalInput, 0f);

        transform.Translate(movement * _moveSpeed * Time.deltaTime);

        bool isMoving = Mathf.Abs(horizontalInput) > 0.1f;
        _animator.SetBool("isRun", isMoving);
    }

    private void FlipCharacter(float horizontalInput)
    {
        if (horizontalInput > 0)
            _spriteRenderer.flipX = false;
        else
            _spriteRenderer.flipX = true;
    }
}
