using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboMult : MonoBehaviour
{

    public Score score;
    
    public float point_time;


    // Start is called before the first frame update
    void Start()
    {
      score.points = 100;  
    }

    // Update is called once per frame
    void Update()
    {
      if(((Time.time - point_time) > 3.0) && (score.points > 100))
      {
      	score.points = 100;
      }  
    }
    
    void OnCollisionEnter2D(Collision2D theCollision)
    {
      if(theCollision.gameObject.name != "PlayerBody" || theCollision.gameObject.name != "Line" || theCollision.gameObject.name != "Line (1)" || theCollision.gameObject.name != "Line (2)" || theCollision.gameObject.name != "Line (3)")
      {
        score.points = score.points + 100;
        //Debug.Log(score.points);
        point_time = Time.time;
      }
    }

}
