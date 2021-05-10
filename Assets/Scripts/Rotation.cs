using UnityEngine;
using System.Collections;

 public class Rotation : MonoBehaviour
 {
     public GameObject target;
     public float speed = 200;
     public Vector3 direction = Vector3.up;


     void FixedUpdate()
     {

         transform.RotateAround(target.transform.position, direction, speed * Time.deltaTime);
		//transform.Rotate(direction, Space.Self);
    	}

 }
