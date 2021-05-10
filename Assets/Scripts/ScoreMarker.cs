using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMarker : MonoBehaviour
{

    public Score score;
    public Text scText;
    
    // Start is called before the first frame update
    void Start()
    {
        score.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scText.text = "" + score.value + "\n Combo Mult: x" + score.points/100;
        if (score.value > score.highscore)
        {
        	score.highscore = score.value;
        }
    }
}
