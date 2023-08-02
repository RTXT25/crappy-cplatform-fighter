using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class move : MonoBehaviour{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float jumpHoldForce = 2.5f;
    public float normalFall = 5f;
    public float fallMult = 2.5f;
    static public int maxJumps = 2;
    bool initiatedJump = false;
    CharacterController controller;
    bool inFastFall;
    static public bool isGround;
    static public int jumpsLeft;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.2f;

    // Jump-related variables
    bool isJumping = false;
    float verticalVelocity = 0f;

    void Awake(){
        controller = GetComponent<CharacterController>();
    }
    void Start(){
        jumpsLeft = maxJumps;
    }
    void Update(){
        // Ground check
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Jump input detection
        if (isGround && verticalVelocity < 0)
        {
            // Reset jumps when grounded
            jumpsLeft = maxJumps;
            verticalVelocity = -2f; // To keep the player slightly grounded
            isJumping = false; // Reset the jump flag when grounded
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
        {
            // Perform initial jump
            verticalVelocity = jumpForce;
            isJumping = true;
            initiatedJump = true; // Set the flag to true when the player initiates the jump
            jumpsLeft--;
        }

        // Continuous jump while the jump button is held
        if (isJumping && Input.GetKey(KeyCode.Space))
        {
            verticalVelocity += jumpHoldForce * Time.deltaTime;
        }

        // If the player leaves the ground without jumping, remove a jump
        if (!isJumping && !initiatedJump)
        {
            initiatedJump = false; // Reset the flag for the next jump attempt
            if (jumpsLeft < maxJumps)
            {
                jumpsLeft++;
            }
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
    }


    void FixedUpdate(){
        float wantX = Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime * moveSpeed;
        float wantY = verticalVelocity * Time.fixedDeltaTime;

        Vector3 moveDirection = new Vector3(wantX, wantY, 0);
        controller.Move(moveDirection);
    }
}