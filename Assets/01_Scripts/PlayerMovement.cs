using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float gravity = 9.8f;
    public bool canMove = true;
    public Animator animator;
    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    void Start()
    {            
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {            
         
        isGrounded = controller.isGrounded;
        if(canMove)
        {
            // Movimiento horizontal (WASD)
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            Vector3 move = transform.right * moveX + transform.forward * moveZ;

            // Aplicamos movimiento horizontal
            controller.Move(move * moveSpeed * Time.deltaTime);

            bool isMoving = move.magnitude > 0.1f;

            // Si estamos en el suelo, reseteamos la velocidad vertical
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;  // Mantener al personaje pegado al suelo
            }

            // Aplicamos gravedad
            velocity.y -= gravity * Time.deltaTime;

            // Movimiento vertical (solo gravedad)
            controller.Move(velocity * Time.deltaTime);

            if (isMoving)
            {
                animator.SetBool("IsMoving", true);
            }
            else
            {
                animator.SetBool("IsMoving", false);
            }
        }
       
    }
}
