using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float sprintSpeed = 20f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 4f;

    public float dashDistance = 15f;   
    public float dashCooldown = 3f; 
    private bool isDashing = false;   
    public Image dashBgImg;
    public AudioSource dashSource;
    public AudioClip dashSfx;



    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public AudioSource footstepSource;
    public AudioClip footstepSfx;
    private float footstepCooldown = 0.35f; 
    private bool canPlayFootstep = true; 
    

    Vector3 velocity;
    bool isGrounded;

  
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;



        // Koşma kontrolü
        float currentSpeed = speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = sprintSpeed;
            footstepCooldown = 0.25f;
        }
        else
        {
            footstepCooldown = 0.35f;
        }

        Vector3 moveVelocity = move * currentSpeed;



        //FootstepSfx Calma Kontrlu
        if (isGrounded && move != Vector3.zero)
        {
            if (canPlayFootstep)
            {
                footstepSource.PlayOneShot(footstepSfx);
                canPlayFootstep = false; 
                StartCoroutine(ResetFootstepCooldown());
            }
        }
           
        

        // Dash atışı
        if (Input.GetKeyDown(KeyCode.CapsLock) && !isDashing && isGrounded)
        {
            
            StartCoroutine(Dash(move));
        }

        // Zıplama
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime + moveVelocity * Time.deltaTime);
    }


      private IEnumerator ResetFootstepCooldown()
    {
        yield return new WaitForSeconds(footstepCooldown);
        canPlayFootstep = true; 
    }


    private IEnumerator Dash(Vector3 moveDirection)
    {
        isDashing = true;
        dashSource.PlayOneShot(dashSfx);
        
        dashBgImg.fillAmount = 0;
        Vector3 targetPosition = transform.position + moveDirection.normalized * dashDistance;

        float dashTime = 0.5f; 
        float elapsedTime = 0f;
        

        while (elapsedTime < dashTime)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, elapsedTime / dashTime);
            newPosition.y = transform.position.y;
            transform.position = newPosition;
            dashBgImg.fillAmount = elapsedTime / dashTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        dashBgImg.fillAmount = 1;
    }
}
