using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBall : MonoBehaviour
{

  public float speed;
  public Rigidbody2D rb;
  public float point_time;

    // Start is called before the first frame update
    void Start()
    {
    		Vector3 velo = new Vector3(Random.Range(-5f, 5f),Random.Range(-5f, 5f),Random.Range(-5f, 5f));
		rb.velocity = (velo * speed);
		point_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
      if(((Time.time - point_time) > 15.0))
      {
      	Destroy(gameObject);
      }  
 
    }
}
