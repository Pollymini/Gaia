using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelosity;
    private bool isGrounded;
    public float fallSpeed = -2f;
    public float speed = 5f;
    public float sprint = 3f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    public bool crouching = false;
    public float crouchTimer = 1;
    public bool lerpCrouch = false;
    public bool sprinting = false;
  
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
       
        isGrounded = controller.isGrounded;
        if (lerpCrouch) 
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
                controller.height = Mathf.Lerp(controller.height, 1, p);
            else
                controller.height = Mathf.Lerp(controller.height, 2, p);

            if (p > 1) 
            {
                lerpCrouch = false;
                crouchTimer = 0f;
            
            }


        }
        //aceleration
        
        if (!isGrounded && playerVelosity.y < 0)
            playerVelosity.y += fallSpeed * Time.deltaTime;
        if (!isGrounded && playerVelosity.y < -4)
            playerVelosity.y = -4;

    }

   
   
    //reacive the inputs for our inputManager.cs and apply to our character controller.
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        // Ускорение действует на всю скорость прыжок + ходьба + бег нужно отделить бег от хотьбы
        controller.Move(transform.TransformDirection(moveDirection)* speed * Time.deltaTime);
        playerVelosity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelosity.y < 0)
            playerVelosity.y = -2f;
        controller.Move(playerVelosity* speed * Time.deltaTime);
        Debug.Log(playerVelosity.y);
    
    }
    public void Jump()
    {
        if (isGrounded)
        {
            playerVelosity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    public void Crouch() 
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }

    public void Sprint() 
    {
        sprinting = !sprinting;
        if (sprinting)
            speed += speed + sprint;
        else
            speed -= speed - sprint;
       
            
    }
     





}

