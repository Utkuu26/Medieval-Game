using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;      
    public float sprintSpeed = 10f;   
    public float dashDistance = 5f;   
    public float dashCooldown = 1.5f; 
    private bool isDashing = false;   
    public float mouseSensitivity = 0.1f; 

    private Rigidbody rb;
    private Vector3 moveDirection;   

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Mouse ile bakılan yöne dönme
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 lookDirection = hit.point - transform.position;
            lookDirection.y = 0f; 

            if (lookDirection != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(lookDirection);
                transform.rotation = rotation;
            }
        }

        // Player hareketi
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Koşma kontrolü
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;
        Vector3 moveVelocity = moveDirection * currentSpeed;

        // Dash atışı
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing)
        {
            StartCoroutine(Dash());
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);
        // transform.Rotate(Vector3.left * mouseY);

        rb.velocity = new Vector3(moveVelocity.x, rb.velocity.y, moveVelocity.z);
    }

    private IEnumerator Dash()
    {
        isDashing = true;

        Vector3 dashDirection = transform.forward * dashDistance;
        Vector3 originalPosition = transform.position;
        Vector3 targetPosition = originalPosition + dashDirection;

        float dashTime = 0.5f;
        float elapsedTime = 0f;

        while (elapsedTime < dashTime)
        {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / dashTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
    }
}
