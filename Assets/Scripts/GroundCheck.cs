
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float checkRadius = 0.15f;

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(
            transform.position,
            checkRadius,
            groundLayer
        ) != null;
    }
}
