using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Player player;
    private UserActions actions;
    private Rigidbody2D rigidBody;
    private PlayerAnimation playerAnimation;

    private Vector2 moveDirection;

    [Header("Config")]
    [SerializeField] private float moveSpeed = 5f;

    private void Awake()
    {
        player = GetComponent<Player>();
        actions = new UserActions();
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        ReadMovement();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ReadMovement()
    {
        moveDirection = actions.Movement.Move.ReadValue<Vector2>();;
        playerAnimation.SetMoveBoolTransition(moveDirection != Vector2.zero);
        playerAnimation.SetMoveAnimation(moveDirection);
    }

    private void Move()
    {
        if (rigidBody == null || player.Stats.currentHealth <= 0) 
            return;

        rigidBody.MovePosition(rigidBody.position + moveDirection * (moveSpeed * Time.fixedDeltaTime));
    }

    private void OnEnable()
    {
        if (actions != null)
            actions.Enable();
    }

    private void OnDisable()
    {
        if (actions != null)
            actions.Disable();
    }
}

