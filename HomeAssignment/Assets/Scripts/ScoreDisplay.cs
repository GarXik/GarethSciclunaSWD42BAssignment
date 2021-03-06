﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    GameSession gameSession;
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        //gameSession = FindObjectOfType<GameSession>();
        scoreText.text = gameSession.GetScore().ToString();
        //print(gameSession.GetScore().ToString());
    }
}
