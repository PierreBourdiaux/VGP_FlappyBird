using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerControler : MonoBehaviour
{

    public float jumpForce = 200;
    public float rotationSpeed =3; 
    public Rigidbody2D rb;

    bool isDead = false;
    bool isReady = false;

    public Animator animator;

    void Start()
    {
        rb.bodyType = RigidbodyType2D.Kinematic; // the player will not be affected by gravity
        GameManager.OnGameStart += OnGameStarted;
    }




    void OnGameStarted()
    {
        rb.bodyType = RigidbodyType2D.Dynamic; // the player will be affected by gravity
        rb.velocity = Vector2.zero; // reset the velocity
        isReady = true;
    }

    void Update()
    {
       if (isReady && !isDead){
        float angle, rotspeed = rotationSpeed;
        if(rb.velocity.y < -2){
            angle = Mathf.Lerp(-90, 90, rb.velocity.y);
        }
        else {
            angle = 20;
            rotspeed *=3;
        }

        Quaternion rotation = Quaternion.Euler(0, 0, angle); // create a quaternion with the angle, conversion for unity
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotspeed * Time.deltaTime); // slerp is a smooth rotation
        
        if (Input.GetMouseButtonDown(0)){
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
        }

       }
    }


    void OnCollisionEnter2D(Collision2D other){
        Die(); // we don't need to specify the object that we collided with, in any case we will die
    }
    void Die(){
        if(!isDead){
            isDead = true;
            animator.speed = 0;
            transform.DORotate(new Vector3(0, 0, -90), 0.5f); // rotate the player 90 degrees in 0.5 seconds
            GameManager.Instance.GameOver();
        }
    }


    void OnDestroy()
    {
        GameManager.OnGameStart -= OnGameStarted;
    }

}
