using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score = 0;
    private void SetupSingleton()
    {
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;
        //if there is more than one music player destroy the last one
        if (numberOfGameSessions > 1)//if there is already the first music player this will run
        {
            Destroy(gameObject);
            print("Destroyed extra gameSession");
        }
        else// will run on the first created music player
        {
            //Do not destroy on changing scenes
            print("Preventing destroy on load - gameSession");
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Awake()
    {
        SetupSingleton();
    }

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int addScore)
    {
        score += addScore;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
