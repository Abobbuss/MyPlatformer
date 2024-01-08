using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    [SerializeField] private float _minJumpForce = 1f;
    [SerializeField] private float _maxJumpForce = 6f;
    [SerializeField] private float _jumpTime = 0.25f;

    private CheckGround _checkGround;
    private Rigidbody2D _rb;
    private const string jumpInput = "Jump";
    private float _jumpTimeCounter;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _jumpTimeCounter = _jumpTime;
        _checkGround = GetComponentInChildren<CheckGround>();
    }
    private void Update()
    {

        if (Input.GetButtonDown(jumpInput) && _checkGround.GetIsGrounded())
            StartJump();

        if (Input.GetButton(jumpInput))
            ContinueJump();

        if (Input.GetButtonUp(jumpInput))
            EndJump();
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
        else
        {
            EndJump();
        }
    }

    private void EndJump()
    {
    }
}
