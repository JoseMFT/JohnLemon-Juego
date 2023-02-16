using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov: MonoBehaviour {
    float horizontal, vertical, charRotation;
    public float rotSpeed = 80f, movSpeed = 2f;
    Vector3 movement, orientation;
    bool isWalking = false;

    Animator charAnimator;
    public Animation animWalking, animIdle;
    // Start is called before the first frame update
    void Start () {
        charAnimator = GetComponent<Animator> ();
        if (gameObject.transform.localRotation.y != 90f) {
            transform.rotation = Quaternion.Euler (0f, 90f, 0f);
        }
    }

    // Update is called once per frame
    void Update () {
        horizontal = Input.GetAxis ("Horizontal");
        vertical = Input.GetAxis ("Vertical");
        charRotation += horizontal * Time.deltaTime * rotSpeed;

        if (Input.GetAxis ("Vertical") != 0f) {
            isWalking = true;
        } else {
            isWalking = false;
        }
        /*if (isWalking == true &&) {
            charAnimator.Play = (animWalking, isWalking);
        }*/
        orientation = new Vector3 (0f, charRotation, 0f);
        movement = transform.forward * vertical * movSpeed;
        movement.Normalize ();
        transform.rotation = Quaternion.Euler (orientation);
        transform.position += movement * Time.deltaTime;
    }
}
