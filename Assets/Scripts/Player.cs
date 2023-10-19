using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Vars for speeds
    [SerializeField] private float speed;

    //Vars for movement
    private Vector3 _moveDir;

    //For Candy Scoring
    int candyScore = 0;
    [SerializeField] TMP_Text scoreText;


    void Start()
    {
        InputManager.Init(this);
        scoreText.text = "Score: " + candyScore;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=  (speed * Time.deltaTime * _moveDir);
        
    }

    public void setMovementDirection(Vector2 newDirection)
    {
        _moveDir = newDirection;

    }


    public void gotCandy(int amount)
    {
        candyScore += amount;
        scoreText.text = "Score: " + candyScore;
    }


    public void gameEnded()
    {

    }
}
