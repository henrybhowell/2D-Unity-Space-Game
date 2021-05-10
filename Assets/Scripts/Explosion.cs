using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    Animator animator;

    string animationState = "AnimationState";

    public Score score;

    public GameObject powerUpC;
    
    public GameObject powerUpM;

    public GameObject powerUpS;

    enum CharStates
    {
      explosion = 1
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator OnCollisionEnter2D(Collision2D theCollision)
    {
      if(theCollision.gameObject.name == "Circle" || theCollision.gameObject.name == "MultiBall(Clone)" || theCollision.gameObject.name == "Shield(Clone)" 
      || theCollision.gameObject.name == "Bomb")
      {
        score.value = score.value + score.points;
        gameObject.GetComponent<Collider2D>().enabled = false;

        if (powerUpC != null && powerUpM != null )
        {
        	float random = Random.Range(0f, 100f);
        	if (random < 20f) 
        	{
        		Instantiate(powerUpC, transform.position, Quaternion.identity);
        	}
        	else if (random < 40f)
        	{
        		Instantiate(powerUpM, transform.position, Quaternion.identity);
        	}

          else if (random < 60f)
        	{
        		Instantiate(powerUpS, transform.position, Quaternion.identity);
        	}
        }

        animator.SetInteger(animationState, (int) CharStates.explosion);
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
      }
    }

    /*private void UpdateState()
    {
      if (Input.GetKeyDown("p"))
        {
          animator.SetInteger(animationState, (int) CharStates.explosion);
        }
    }*/
}
