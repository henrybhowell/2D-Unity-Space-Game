using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour {

    public GameObject ship;
    public GameObject ball;
    Rigidbody shipRb;
    Rigidbody2D rb;

    Vector3 shipLastPos;
    public Vector3 shipVelocity;

    public float ballThrowingForce = 100f;
    public bool holdingBall = true;


    private void Start ()
    {
        rb = ball.GetComponent<Rigidbody2D> ();
        shipRb = ship.GetComponent<Rigidbody> ();
    }

    void FixedUpdate ()
    {
        Vector2 directionRay = (ball.transform.position-ship.transform.position);

        // update velocity (from mundy help)
        shipVelocity = (shipRb.position - shipLastPos) * 50;
        shipLastPos = shipRb.position;
        //Debug.Log (shipVelocity);

        if (Input.GetKey(KeyCode.E)) {
            //print ("pressed return key");
            
            if(ball.transform.parent != null){
                Debug.Log("child");
                rb.velocity = new Vector2(0f,0f);
                holdingBall = true;
            }

            if (holdingBall) {
            //print ("holding ball");
            	holdingBall = false;
            	rb.AddForce(transform.up * ballThrowingForce);
            	transform.parent = null;
            }

            // Ball stops and becomes a child of the ship when laser hits it
            //if (Physics2D.Raycast(ship.transform.position, directionRay, 10, 1))
            //{
            //    holdingBall = true;
            //    rb.velocity = new Vector2(0f,0f);
           // }
            
        }
        rb.velocity = rb.velocity * new Vector2(1f, 1f);
    }

}
