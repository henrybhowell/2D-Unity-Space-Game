using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackBall : MonoBehaviour {

	private Rigidbody2D rb;
	private Vector2 direction;
	private float moveSpeed = 50f;

	public Transform target;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update ()
	{
		 Vector3 pos = Camera.main.WorldToViewportPoint(target.position);
		// on click
		if (target != null) {
			// create a normalized direction vector 
			direction = (target.position - transform.position).normalized;
			if ((pos.x < 0 || pos.x > 1) || (pos.y < 0 || pos.y > 1)) {
				this.GetComponent<SpriteRenderer>().enabled = true;
			} else {
				this.GetComponent<SpriteRenderer>().enabled = false;
			}
			// set velocity
			rb.velocity = new Vector2 (direction.x * moveSpeed, direction.y * moveSpeed);
		} else {
			rb.velocity = Vector2.zero;
		}
	}
}
