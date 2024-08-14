using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    private const string JumpInput = "Jump";

    [SerializeField] private float _minJumpForce = 1f;
    [SerializeField] private float _maxJumpForce = 6f;
    [SerializeField] private float _jumpTime = 0.25f;

    private GroundCheck _checkGround;
    private Rigidbody2D _rigidbody2d;
    private float _jumpTimeCounter;

    private void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _jumpTimeCounter = _jumpTime;
        _checkGround = GetComponentInChildren<GroundCheck>();
    }
    private void Update()
    {
        if (Input.GetButtonDown(JumpInput) && _checkGround.GetIsGrounded())
            StartJump();

        if (Input.GetButton(JumpInput))
            ContinueJump();
    }

    private void StartJump()
    {
        _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, _minJumpForce);
        _jumpTimeCounter = _jumpTime;
    }

    private void ContinueJump()
    {
        if (_jumpTimeCounter > 0)
        {
            float jumpForce = Mathf.Lerp(_minJumpForce, _maxJumpForce, 1 - (_jumpTimeCounter / _jumpTime));

            _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, jumpForce);
            _jumpTimeCounter -= Time.deltaTime;
        }
    }
}
