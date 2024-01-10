using UnityEngine;


public class GroundCheck : MonoBehaviour
{
    [SerializeField] private float rayDistance = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    public bool GetIsGrounded()
    {
        return Physics2D.OverlapCircle(transform.position, rayDistance, groundLayer) != null;
    }
}

