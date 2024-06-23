using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score;   
    public int highScore;

    void Awake()
    {
        Instance = this;
    }

    void Start(){
        score = 0;

        if(PlayerPrefs.HasKey("highScore")){
            highScore = PlayerPrefs.GetInt("highScore");
        }
        else{
            highScore = 0;
        }
    }


    public void AddScore(){
        score++;
        UIControlleur.Instance.UpdateScore(score);
        if(score > highScore){
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
        }
    }
}
