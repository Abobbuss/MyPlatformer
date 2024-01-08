using UnityEngine;


public class CheckGround : MonoBehaviour
{
    [SerializeField] private float rayDistance = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private bool _isGrounded;

    private void FixedUpdate()
    {
        _isGrounded = IsGrounded();
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(transform.position, rayDistance, groundLayer) != null;
    }

    public bool GetIsGrounded() => _isGrounded;
}

