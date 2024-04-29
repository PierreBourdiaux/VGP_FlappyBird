using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class scrollingBackGround : MonoBehaviour
{
    public float backgroundSpeed = 0.1f;
    float spriteSize;

    public SpriteRenderer backgroundSprite;

    private Vector3 startPosition;

    void Awake()
    {
    }

    void Start()
    {
        startPosition = transform.position;
        spriteSize = backgroundSprite.bounds.size.x + backgroundSprite.transform.localScale.x;
    }

    void Update()
    {
        //mathf.repeat -> the rest of the division
        float newPosition = Mathf.Repeat(Time.time * backgroundSpeed, spriteSize);
        transform.position = startPosition + Vector3.left * newPosition;
    }
}
