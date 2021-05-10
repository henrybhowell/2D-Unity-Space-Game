using UnityEngine;

[CreateAssetMenu(menuName = "Score")]
public class Score : ScriptableObject
{
    public float value;
    public int points;
    public float highscore;
}
