using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    [SerializeField] private float _minJumpForce = 1f;
    [SerializeField] private float _maxJumpForce = 6f;
    [SerializeField] private float _jumpTime = 0.25f;

    private GroundCheck _checkGround;
    private Rigidbody2D _rb;
    private float _jumpTimeCounter;

    private const string JumpInput = "Jump";

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
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
        _rb.velocity = new Vector2(_rb.velocity.x, _minJumpForce);
        _jumpTimeCounter = _jumpTime;
    }

    private void ContinueJump()
    {
        if (_jumpTimeCounter > 0)
        {
            float jumpForce = Mathf.Lerp(_minJumpForce, _maxJumpForce, 1 - (_jumpTimeCounter / _jumpTime));

            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            _jumpTimeCounter -= Time.deltaTime;
        }
    }
}
