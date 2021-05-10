using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipExplosion : MonoBehaviour
{
    Animator animator;

    string animationState = "ShipState";

    public GameObject mball;

    public GameObject shield;

    public Score score;

    enum CharStates
    {
      ShipExplosion = 1,
      explosion = 2
    }
    // Start is called before the first frame update
    void Start()
    {
      GameObject go = GameObject.Find ("PlayerBody");
      GameObject ball = GameObject.Find ("Circle");
      animator = go.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator OnCollisionEnter2D(Collision2D theCollision)
    {
      GameObject go = GameObject.Find ("PlayerBody");
      GameObject ball = GameObject.Find ("Circle");

	if (theCollision.gameObject.name == "PowerUp_Combo(Clone)"){
	 	score.value = score.value + score.points + 500;
      	score.points = score.points + 500;
        	Destroy(theCollision.gameObject);
	 }

	else if (theCollision.gameObject.name == "PowerUp_Multi(Clone)"){
	 	Instantiate(mball, theCollision.gameObject.transform.position, Quaternion.identity);
        	Destroy(theCollision.gameObject);
	 }

  else if (theCollision.gameObject.name == "PowerUp_Shield(Clone)"){
	 	Instantiate(shield, theCollision.gameObject.transform.position, Quaternion.identity);
        	Destroy(theCollision.gameObject);
	 }

      else if (theCollision.gameObject.name != "Circle" && theCollision.gameObject.name != "Shield(Clone)" && theCollision.gameObject.name != "MultiBall(Clone)"
      && theCollision.gameObject.name != "Bomb"){

        Debug.Log(theCollision.gameObject.name);
        go.GetComponent<ShipManeuver>().enabled = false;
        ball.GetComponent<Collider2D>().enabled = false;
        animator.SetInteger(animationState, (int) CharStates.ShipExplosion);
        yield return new WaitForSeconds(3);
        if (go){
          Destroy(go);
        }
        Destroy(gameObject);
        SceneManager.LoadScene("StartMenu");
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
