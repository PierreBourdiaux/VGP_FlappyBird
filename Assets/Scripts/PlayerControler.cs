using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    public float jumpForce = 200;
    public float rotationSpeed =3; 
    public Rigidbody2D rb;

    bool isDead = false;
    bool isReady = false;

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


    void OnDestroy()
    {
        GameManager.OnGameStart -= OnGameStarted;
    }

}
