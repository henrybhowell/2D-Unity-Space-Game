using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// deals with each instance of space junk
public class SpaceJunk : MonoBehaviour
{
    public Vector3 origin;
    public Vector3 destination;
    public float speed;

    // Start is called before the first frame update
    public void Init(Vector3 start, Vector3 target)
    {
        origin = start;
        destination = target;
        speed = Random.Range(2,5); // randomize speed of junks movement
    }

    // Update is called once per frame
    void Update()    {
        // move game object from origin to destination
        // distance to move each frame = normalized distance vector * speed * time since last frame
        float step = speed * Time.deltaTime;
        if (transform.position == destination)
        {
            Destroy(gameObject); // get rid of game object once it has reached its destination

        }else{
            transform.position = Vector3.MoveTowards(transform.position, destination, step);
        }
        
    }

}
