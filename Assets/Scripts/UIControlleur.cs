using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;

public class UIControlleur : MonoBehaviour
{
    public static UIControlleur Instance;

    public CanvasGroup GameOverMenu;
    public CanvasGroup GamePlay;
    public CanvasGroup MainMenu;

    public Text scoreText;

    public GameObject StartGameUI;

    public GameObject RestartGame;
    public GameObject GameOverPanel;

    public Text highScoreText;
    public Text currentScoreText;



    void Awake(){
        Instance = this;

        GameManager.OnGameStart += OnGameStart;
        GameManager.OnGameEnd += OnGameEnd;
    }

    void Start(){
        MainMenu.alpha = 1;
        GamePlay.alpha = 0;
        GameOverMenu.alpha = 0;

        GameOverMenu.gameObject.SetActive(false);
        GamePlay.gameObject.SetActive(false);

    }

    void OnGameStart(){
        MainMenu.DOFade(0,0.5f).OnComplete(()=>{
            MainMenu.gameObject.SetActive(false);
        });

        GamePlay.gameObject.SetActive(true);
        GamePlay.DOFade(1,0.5f);
    }

    void OnGameEnd(){
        GamePlay.DOFade(0,0.5f).OnComplete(()=>{
            MainMenu.gameObject.SetActive(false);
        });
        GameOverMenu.gameObject.SetActive(true);

        //set the score
        highScoreText.text = ScoreManager.Instance.highScore.ToString();
        currentScoreText.text = ScoreManager.Instance.score.ToString();

        GameOverPanel.transform.localScale = Vector3.zero;
        RestartGame.transform.localScale = Vector3.zero;

        GameOverMenu.DOFade(1,0.4f).SetDelay(0.5f).OnComplete(()=> GameOverPanel.transform.DOScale(1,0.4f).SetEase(Ease.OutBack).OnComplete(()=> RestartGame.transform.DOScale(1,0.4f).SetEase(Ease.OutBack)));



    }

    public void UpdateScore(int score){
        scoreText.text = score.ToString();
        scoreText.transform.DOPunchScale(Vector3.one * 0.25f,0.3f);
    
    }


    public void TriggerStartGame(){
        StartGameUI.SetActive(false);
        GameManager.Instance.StartGame();
    }

    public void OnDestroy(){
        GameManager.OnGameEnd -= OnGameEnd;
        GameManager.OnGameStart -= OnGameStart;
    }
}
