using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    float speed;
    float distanceBetweenPipes;
    float numberOfPipes;

    float startPositionY; // for random position


    public Collider2D[] colliders;
    void Start(){

        GameManager.OnGameEnd+= OnGameEnded;

        speed = GameManager.Instance.speedPipes;
        distanceBetweenPipes = GameManager.Instance.distanceBetweenPipes;
        numberOfPipes = GameManager.Instance.numberOfPipes;
    
    
        startPositionY = transform.position.y;
        transform.position = new Vector3(transform.position.x, startPositionY + Random.Range(-2, 2), transform.position.z);
    }

    void OnDestroy(){
        GameManager.OnGameEnd -= OnGameEnded;
    }

    void OnGameEnded(){
        foreach (Collider2D col in colliders){
            col.enabled = false;
        }
    }

    void Update()
    {
        if (GameManager.Instance.currentGameState == GameManager.GameState.InGame)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }

    public void UpdatePosition(){
        Debug.Log("last position" +transform.position);
        //transform.position = new Vector3(transform.position.x + distanceBetweenPipes * numberOfPipes, Random.Range(-2, 2) , transform.position.z);
        transform.position = new Vector3(transform.position.x + distanceBetweenPipes * numberOfPipes, Random.Range(-2, 2) , transform.position.z);
        //write in the console the new position
        Debug.Log("new position" + transform.position);
    }
}
