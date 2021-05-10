using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public GameObject bomb;
    public CircleCollider2D bomb_circ;
    public float width = 0.0f;
    public float height = 0.0f;
    private Vector3 scaleChange;
    public Rigidbody2D rb;

    
    

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody2D rb = bomb.AddComponent<Rigidbody2D>();
        // shield.SetActive(true);
        bomb_circ = GetComponent<CircleCollider2D>();

        bomb_circ.radius = 0;
        
        scaleChange = new Vector3(0.07f, 0.07f, 0.0f);
        
        // rb.detectCollisions = false;

        
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.isKinematic = false;

        if(Input.GetKey(KeyCode.Q))
        {
            rb.isKinematic = true;
            // rb.detectCollisions = true;

            while (width < 10f){
                width = width+0.07f;
                bomb_circ.radius = bomb_circ.radius+=0.01f;
                bomb.transform.localScale += scaleChange;
                
            }
        
            rb.isKinematic = false;
            // rb.detectCollisions = false;
        }
        
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name != "Circle"){
            Debug.Log("hit!!");
        }
        
    }
}
