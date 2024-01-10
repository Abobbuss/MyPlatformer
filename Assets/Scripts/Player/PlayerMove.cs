using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Animator _animator;

    private SpriteRenderer _spriteRenderer;
    private int _isRunHash;

    private const string HorizontalInput = "Horizontal";
    private const string BoolVariableRun = "isRun";


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _isRunHash = Animator.StringToHash(BoolVariableRun);
    }

    private void Update()
    {
        float horizontalMove = Input.GetAxis(HorizontalInput);

        MovePlayer(horizontalMove);

        if (horizontalMove != 0)
            FlipCharacter(horizontalMove);
    }

    private void MovePlayer(float horizontalInput)
    {
        Vector2 movement = new Vector2(horizontalInput, 0f);

        transform.Translate(movement * _moveSpeed * Time.deltaTime);

        bool isMoving = Mathf.Abs(horizontalInput) > 0.1f;
        _animator.SetBool(_isRunHash, isMoving);
    }

    private void FlipCharacter(float horizontalInput)
    {
        _spriteRenderer.flipX = horizontalInput < 0;
    }
}
