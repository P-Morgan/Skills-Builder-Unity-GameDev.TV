// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] int score;
        
    void Start() 
    {
        scoreText.text = score.ToString();
    }


    public void addpoints(int points)
    {
        score = score + points;
        scoreText.text = score.ToString();
    }
}
