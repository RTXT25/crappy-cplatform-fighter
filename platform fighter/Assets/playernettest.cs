using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class playernettest : NetworkBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float jumpHoldForce = 2.5f;
    public float normalFall = 5f;
    public float fallMult = 2.5f;
    public int maxJumps = 2;

    CharacterController controller;
    [SerializeField] bool isGround;
    int jumpsLeft;

    // For detecting ground, you can use a simple transform at the player's feet
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.2f;

    // Jump-related variables
    bool isJumping = false;
    float verticalVelocity = 0f;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        jumpsLeft = maxJumps;
    }

    void Update()
    {
        if (!isLocalPlayer) return;

        // Ground check
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Jump input detection
        if (isGround && verticalVelocity < 0)
        {
            jumpsLeft = maxJumps;
            verticalVelocity = -2f; // To keep the player slightly grounded
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
        {
            verticalVelocity = jumpForce;
            isJumping = true;
            jumpsLeft--;
            CmdPerformJump();
        }

        // Continuous jump while the jump button is held
        if (isJumping && Input.GetKey(KeyCode.Space))
        {
            verticalVelocity += jumpHoldForce * Time.deltaTime;
        }

        // Apply gravity
        if (!isGround)
        {
            verticalVelocity -= normalFall * Time.deltaTime;
        }

        // Fast Fall mechanic
        if (Input.GetKey(KeyCode.DownArrow))
        {
            verticalVelocity -= fallMult * normalFall * Time.deltaTime;
        }

        CmdUpdateMovement(verticalVelocity);
    }

    [Command]
    void CmdPerformJump()
    {
        RpcJump();
    }

    [ClientRpc]
    void RpcJump()
    {
        // Client-side jump handling (if required)
    }

    [Command]
    void CmdUpdateMovement(float verticalVel)
    {
        RpcUpdateMovement(verticalVel);
    }

    [ClientRpc]
    void RpcUpdateMovement(float verticalVel)
    {
        if (!isLocalPlayer)
        {
            verticalVelocity = verticalVel;
            Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed, verticalVelocity * Time.deltaTime, 0);
            controller.Move(moveDirection);
        }
    }
}
