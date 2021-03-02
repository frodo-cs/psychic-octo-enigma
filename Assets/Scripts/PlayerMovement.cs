using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] float currentSpeed;
    [SerializeField] float gravity = 20.0f;
    [SerializeField] float speedMultiplier = 1.0f;

    private AudioSource step;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private Animator animator;
    private bool backwards;
    private const float walkSpeed = 5.5f;
    private const float backSpeed = 4f;

    private void Start() {
        step = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (controller.isGrounded) {
            backwards = Input.GetAxis("Vertical") < 0;
            currentSpeed = Input.GetAxis("Vertical") != 0 ?  Input.GetAxis("Vertical") > 0 ? walkSpeed : backSpeed : 0;
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= currentSpeed * speedMultiplier;
            StepSound();
        }
        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
        moveDirection.y -= gravity * Time.deltaTime;     
    }

    private void FixedUpdate() { 
        controller.Move(moveDirection * Time.deltaTime);      
        animator.SetFloat("Speed", currentSpeed);
        animator.SetBool("Backwards", backwards);
    }

    private void StepSound() {
        if (currentSpeed != 0) {
            if (!step.isPlaying) {
                step.Play();
            }
        } else {
            step.Stop();
        }
    }
}