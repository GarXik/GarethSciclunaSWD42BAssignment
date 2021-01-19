using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score = 0;
    [SerializeField] AudioClip gainPointsSound;
    [SerializeField] [Range(0, 1)] float gainPointsSoundVolume = 0.75f;

    private void SetupSingleton()
    {
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;
        //if there is more than one music player destroy the last one
        if (numberOfGameSessions > 1)//if there is already the first game session this will run
        {
            Destroy(gameObject);
            print("Destroyed extra gameSession");
        }
        else// will run on the first created session
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
        //Play Audio
        AudioSource.PlayClipAtPoint(gainPointsSound, Camera.main.transform.position, gainPointsSoundVolume);

        //load Winner Scene if player has 100 points
        if (score >= 100)
        {
            Level levelobj = FindObjectOfType<Level>(); 
            if (levelobj)
            {
                levelobj.LoadWinner();
            }
        }
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
