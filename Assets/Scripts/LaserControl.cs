using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour
{

    public Camera cam;
    public LineRenderer lineRenderer;
    public Transform firePoint;
    public GameObject circle;
    // public float speed = 2.0f;

    Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = circle.GetComponent<Rigidbody2D> ();

        DisableLaser();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 directionRay = (circle.transform.position-firePoint.position);

        
        // UpdateLaser();
        // Debug.Log(firePoint.position);
        // Debug.Log(circle.transform.position);

        if(Input.GetButtonDown("Fire1"))
        {
            if (Physics2D.Raycast(firePoint.position, directionRay, 2, 1)){
            	EnableLaser();  
            
            }
            else{
                DisableLaser();
            }
          
        }
        

        if(Input.GetButton("Fire1"))
        {
           
            if (Physics2D.Raycast(firePoint.position, directionRay, 2, 1))
            {

                // trying to get the laser to retract the ball into the ship slowly

                // Debug.Log(firePoint.position);
                // Debug.Log(firePoint.transform.position * .8f);
                // if(Vector3.Distance(circle.transform.position, firePoint.position) > .8f){
                //     circle.transform.position = firePoint.transform.position * .8f;
                //     // new Vector3(circle.transform.position.x, circle.transform.position.y, 0);
                // }

                UpdateLaser();

                if(circle.transform.parent != firePoint){
                    Debug.Log("hit child");
                    circle.transform.parent = firePoint;
                    circle.transform.up = directionRay;
                    rb.velocity = new Vector2(0f,0f);
                    
                    // circle.transform.position = new Vector3(.8f,.8f,0f) ;
                    
                }
            }
            

        }

        if(Input.GetButtonUp("Fire1"))
        {
            DisableLaser();
        }
        
    }

    void EnableLaser()
    {
        lineRenderer.enabled = true;
    }

    void UpdateLaser()
    {
        lineRenderer.SetPosition(0, firePoint.position);
        
        lineRenderer.SetPosition(1, new Vector3(circle.transform.position.x, circle.transform.position.y, 0));

        
    }

    void DisableLaser()
    {
        lineRenderer.enabled = false;
    }
}
