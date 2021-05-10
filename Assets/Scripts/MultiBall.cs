using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBall : MonoBehaviour
{

  public float speed;
  public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
    		Vector3 velo = new Vector3(Random.Range(-5f, 5f),Random.Range(-5f, 5f),Random.Range(-5f, 5f));
		rb.velocity = (velo * speed);
    }

    // Update is called once per frame
    void Update()
    {
      if(Time.time > 30.0)
      {
      	Destroy(gameObject);
      }  
 
    }
}
