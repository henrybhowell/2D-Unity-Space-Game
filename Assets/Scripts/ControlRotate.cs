using UnityEngine;
using System.Collections;

 public class ControlRotate : MonoBehaviour
 {
     public GameObject target;
     public float speed = 300;
     public Vector3 direction = Vector3.up;
     void FixedUpdate()
     {
	   if (Input.GetKey("space") && (transform.parent != null))
        {
         	//print("space key was pressed");
         	transform.RotateAround(target.transform.position, direction, speed * Time.deltaTime);
	   }
    }
 }
