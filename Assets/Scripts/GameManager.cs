using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    static public event Action OnGameStart;
    static public event Action OnGameEnd;
    

    public enum GameState
    {
        MainMenu,
        InGame,
        GameOver
    }

    public float speedPipes;
    public float distanceBetweenPipes;
    public float numberOfPipes;

    public Pipe pipePrefab;

    public GameState currentGameState = GameState.MainMenu;

    public Transform pipeSpawnPoint;

    void Awake()
    {
        Instance = this;
    
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        //set pipes spawn point
        currentGameState = GameState.MainMenu;
        for(int i = 0; i < numberOfPipes; i++)
        {
            //write the position of the pipe
            Debug.Log(pipeSpawnPoint.position+ new Vector3(i*distanceBetweenPipes, 0, 0));
            Pipe newPipe = Instantiate(pipePrefab, pipeSpawnPoint.position+new Vector3(i*distanceBetweenPipes, 0, 0), Quaternion.identity);
        }
    }

    public void StartGame()
    {
        currentGameState = GameState.InGame;
        OnGameStart?.Invoke();
    }

    public void GameOver()
    {
        currentGameState = GameState.GameOver;
        OnGameEnd?.Invoke();
    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(0); // 0 is the index of the main scene
    }



}
