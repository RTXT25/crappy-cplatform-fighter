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
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGround && verticalVelocity < 0){
            jumpsLeft = maxJumps;
            verticalVelocity = -2f; 
        }

       if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0){
            verticalVelocity = jumpForce;
            isJumping = true;
            jumpsLeft--;
        }
        if (isJumping && Input.GetKey(KeyCode.Space)){
            verticalVelocity += jumpHoldForce * Time.deltaTime;
        }
        if (!isGround) {
            verticalVelocity -= normalFall * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow)){
            verticalVelocity -= fallMult * normalFall * Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        float wantX = Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime * moveSpeed;
        float wantY = verticalVelocity * Time.fixedDeltaTime;

        Vector3 moveDirection = new Vector3(wantX, wantY, 0);
        controller.Move(moveDirection);
    }
}