using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    [Header("Dash Settings")]
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 2f;

    private bool isDashing = false;
    private float dashEndTime = 0f;
    private float lastDashTime = -Mathf.Infinity;
    private Vector3 dashDirection;

    private CharacterController controller;
    private Vector3 moveDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 inputDirection = transform.right * horizontal + transform.forward * vertical;
        moveDirection = isDashing ? dashDirection : inputDirection;

        float currentSpeed = isDashing ? dashSpeed : speed;
        controller.Move(moveDirection * currentSpeed * Time.deltaTime);

        HandleDash();
    }

    void HandleDash()
    {
        // Inicia el dash si se presiona espacio y no está en cooldown
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastDashTime + dashCooldown && !isDashing)
        {
            if (moveDirection != Vector3.zero)
            {
                isDashing = true;
                dashEndTime = Time.time + dashDuration;
                lastDashTime = Time.time;
                dashDirection = moveDirection.normalized;
            }
        }

        // Termina el dash
        if (isDashing && Time.time >= dashEndTime)
        {
            isDashing = false;
        }
    }
}
