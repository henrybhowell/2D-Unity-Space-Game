using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// this is the 2D version

public class ShipManeuver : PhysicsBase {

    public Vector3 direction;           // the direction vector


    // for rotation
    public float rotateTimeElapsed = 0;
    public float rotateDuration = 200;

    public float inputRotateTimeElapsed = 0;
    public float inputRotateDuration = 200;


    public bool receivingInput;

    private void Start ()
    {
        // get container collider
    }

    protected override void Update ()
    {
        base.Update ();

    }

    void LateUpdate ()
    {
       
        // if player input is happening and the current object is targeted
        if (playerInput.magnitude != 0) {
            // get player input
            direction = playerInput;
            // is someone pressing buttons
            receivingInput = true;
        } else {
            // get direction
            receivingInput = false;
        }

        // distance to move each frame = normalized distance vector * speed * time since last frame
        Vector3 step = direction * thrust * Time.deltaTime;

        // add step vector to current position
        rb.MovePosition (transform.position + step);
        //rb.velocity = direction * thrust;

        // is someone pressing buttons
        if (receivingInput == true) {
            // rotate to that direction
            RotateTorwardsDirection2D ();

        } 

    }


    /**
     *  Turn transform towards a direction vector over time
     */
    void RotateTorwardsDirection2D ()
    {
        // Reset other rotate time elapsed if not zero
        if (rotateTimeElapsed != 0) rotateTimeElapsed = 0;

        // Set position to rotate towards based on player input
        Vector3 rotateTo = transform.position + (playerInput * 100);

        // change look direction slowly
        Vector3 temp = Vector3.Lerp (transform.right, (rotateTo - transform.position), inputRotateTimeElapsed / inputRotateDuration);

        // Prevent possible flipping in y rotation
        Transform cloneTransform = transform;
        cloneTransform.right = temp;
        if (cloneTransform.eulerAngles.y != 0) {
            temp = new Vector3 (temp.x, 0.1f, 0);
        }

        // Set right vector
        transform.right = temp;

        inputRotateTimeElapsed += Time.deltaTime;
    }




}