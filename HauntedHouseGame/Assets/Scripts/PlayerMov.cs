using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov: MonoBehaviour {
    float horizontal, vertical, charRotation;
    public float rotSpeed = 20f;
    Vector3 movement, desiredAimSpot;
    Quaternion orientation = Quaternion.identity;
    bool horizontalInput = false, verticalInput = false, isWalking = false;
    Rigidbody charRB;
    Animator charAnimator;

    void Start () {
        charRB = GetComponent<Rigidbody> ();
        charAnimator = GetComponent<Animator> ();
        /*if (gameObject.transform.localRotation.y != -90f) {
            transform.rotation = Quaternion.Euler (0f, -90f, 0f);
        }*/
    }

    void FixedUpdate () {
        horizontal = Input.GetAxis ("Horizontal");
        vertical = Input.GetAxis ("Vertical");
        charRotation += horizontal * Time.deltaTime * rotSpeed;

        horizontalInput = !Mathf.Approximately (horizontal, 0f);
        verticalInput = !Mathf.Approximately (vertical, 0f);
        isWalking = horizontalInput || verticalInput;

        movement.Set (-vertical, 0f, horizontal);
        movement.Normalize ();
        charAnimator.SetBool ("IsWalking", isWalking);
        desiredAimSpot = Vector3.RotateTowards (transform.forward, movement, rotSpeed * Time.deltaTime, 0f);
        orientation = Quaternion.LookRotation (desiredAimSpot);
    }

    public void OnAnimatorMove () {
        charRB.MovePosition (charRB.position + movement * charAnimator.deltaPosition.magnitude);
        charRB.MoveRotation (orientation);
    }
}
