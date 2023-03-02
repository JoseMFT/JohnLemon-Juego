using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMov: MonoBehaviour {
    float horizontal, vertical, charRotation;
    public float rotSpeed = 20f;
    Vector3 movement, desiredAimSpot;
    Vector2 inputMovement;
    Quaternion orientation = Quaternion.identity;
    bool horizontalInput = false, verticalInput = false, isWalking = false;
    Rigidbody charRB;
    Animator charAnimator;
    AudioSource footstepsSFX;

    void Start () {
        charRB = GetComponent<Rigidbody> ();
        charAnimator = GetComponent<Animator> ();
        footstepsSFX = GetComponent<AudioSource> ();
    }

    void FixedUpdate () {
        horizontal = inputMovement.x;
        vertical = inputMovement.y;
        charRotation += horizontal * Time.deltaTime * rotSpeed;

        horizontalInput = !Mathf.Approximately (horizontal, 0f);
        verticalInput = !Mathf.Approximately (vertical, 0f);
        isWalking = horizontalInput || verticalInput;

        charAnimator.SetBool ("IsWalking", isWalking);

        if (isWalking == true) {
            if (!footstepsSFX.isPlaying) {
                footstepsSFX.Play ();
            }
        } else {
            footstepsSFX.Stop ();
        }
        desiredAimSpot = Vector3.RotateTowards (transform.forward, movement, rotSpeed * Time.deltaTime, 0f);
        orientation = Quaternion.LookRotation (desiredAimSpot);
    }

    public void OnAnimatorMove () {
        charRB.MovePosition (charRB.position + movement * charAnimator.deltaPosition.magnitude);
        charRB.MoveRotation (orientation);
    }

    public void OnMovement (InputAction.CallbackContext value) {
        inputMovement = value.ReadValue<Vector2> ();
        //   Debug.Log (inputMovement);
        movement.Set (-inputMovement.y, 0f, inputMovement.x);
        movement.Normalize ();
    }
}
