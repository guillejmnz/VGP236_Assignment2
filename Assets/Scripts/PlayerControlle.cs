
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlle : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private bool isPlayer2 = false;
    [SerializeField] private float JumpSpeed = 5.0f;
    [SerializeField] private float moveSpeed = 5.0f;

    [Header("Components")]
    [SerializeField] private GroundCheck groundCheck = null;
    [SerializeField] private Animator animator = null;
    [SerializeField] private Rigidbody2D rigidbody = null;

    private float desiredSpeed = 0.0f;
    private float direction = 1.0f;
    private bool isJumping = false;
    private bool isFalling = false;

    private Vector3 lastSafePosition = Vector3.zero;

    
    private PlayerInput playerInput = null;
    private InputAction moveAction = null;
    private InputAction jumpAction = null;

    private void Awake()
    {
        playerInput = new PlayerInput();

        
        if (isPlayer2)
        {
            moveAction = playerInput.Player2.Move;
            jumpAction = playerInput.Player2.Jump;
        }
        else
        {
            moveAction = playerInput.Player.Move;
            jumpAction = playerInput.Player.Jump;
        }

        jumpAction.performed += OnJump;

        lastSafePosition = transform.position;

        if (animator != null)
        {
            animator.SetFloat("Direction", direction);
            animator.SetFloat("Speed", 0.0f);
        }
    }

    private void OnEnable()
    {
        moveAction?.Enable();
        jumpAction?.Enable();
    }

    private void OnDisable()
    {
        moveAction?.Disable();
        jumpAction?.Disable();
    }

    private void OnDestroy()
    {
        if (jumpAction != null)
        {
            jumpAction.performed -= OnJump;
        }

        playerInput?.Dispose();
    }

    private void Update()
    {
        if (groundCheck == null || rigidbody == null)
            return;

        desiredSpeed = moveAction.ReadValue<Vector2>().x * moveSpeed;

        if (groundCheck.IsGrounded())
        {
            lastSafePosition = transform.position;

            if (rigidbody.linearVelocityY <= 0.1f)
            {
                isFalling = false;
                isJumping = false;
            }
        }
        else if (rigidbody.linearVelocityY < 0.0f)
        {
            isFalling = true;
            isJumping = false;
        }

        if (desiredSpeed < 0.0f)
        {
            direction = -1.0f;
        }
        else if (desiredSpeed > 0.0f)
        {
            direction = 1.0f;
        }

        if (animator != null)
        {
            float currentSpeed = rigidbody.linearVelocityX;

            animator.SetFloat("Direction", direction);
            animator.SetFloat("Speed", Mathf.Abs(currentSpeed));
            animator.SetBool("IsJumping", isJumping);
            animator.SetBool("IsFalling", isFalling);
        }
    }

    private void FixedUpdate()
    {
        if (rigidbody != null)
        {
            rigidbody.linearVelocityX = desiredSpeed;
        }
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (groundCheck != null &&
            rigidbody != null &&
            groundCheck.IsGrounded() &&
            rigidbody.linearVelocityY < 0.1f)
        {
            rigidbody.linearVelocityY = JumpSpeed;
            isJumping = true;
            isFalling = false;
        }
    }

    public void RespawnPlayer()
    {
        transform.position = lastSafePosition;

        if (rigidbody != null)
        {
            rigidbody.linearVelocity = Vector2.zero;
        }

        desiredSpeed = 0.0f;
        isJumping = false;
        isFalling = false;
    }
}
