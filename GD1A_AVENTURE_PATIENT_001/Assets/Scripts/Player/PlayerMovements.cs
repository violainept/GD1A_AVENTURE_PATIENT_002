using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    [Header("Configurations")]
    [SerializeField] private float moveSpeed;

    public Vector2 moveDirection => movement;

    private PlayerActions actions;
    private Player player;
    private PlayerAnimations playerAnimations;
    private Rigidbody2D rb;
    private Vector2 movement;

    public bool canMove = true;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimations = GetComponent<PlayerAnimations>();
        player = GetComponent<Player>();
    }

    private void Update()
    {
        ReadMovement();
    }

    private void FixedUpdate()
    {
        if (canMove == true)
        {
            Move();
        }
    }

    private void Move() // Player movements
    {
        if (player.Stats.Health <= 0) return;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void ReadMovement() // All axis where Player can move (horizontal & vertical)
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Can't move diagonally
        if (movement.x != 0)
        {
            movement.y = 0;
        }
        if (movement.y != 0)
        {
            movement.x = 0;
        }

        if (movement != Vector2.zero) // Player is motionless
        {
            playerAnimations.SetIdleAnimation(movement);
        }
            playerAnimations.SetMovingAnimation(movement); // Player is moving

    }
}