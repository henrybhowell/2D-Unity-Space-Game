using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPower : MonoBehaviour
{

    public GameObject shield;
    private int shieldHealth = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = shield.AddComponent<Rigidbody2D>();
        shield.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldHealth > 2){
            shield.SetActive(false);
        }
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
        shieldHealth++;
    }
}
