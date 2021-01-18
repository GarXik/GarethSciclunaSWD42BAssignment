using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void SetupSingleton()
    {
        int numberOfMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        //if there is more than one music player destroy the last one
        if (numberOfMusicPlayers > 1)//if there is already the first music player this will run
        {
            Destroy(gameObject);
            print("Destroyed extra musicPlayer");
        }
        else// will run on the first created music player
        {
            //Do not destroy on changing scenes
            print("Preventing destroy on load");
            DontDestroyOnLoad(gameObject);
        }

    }

    // Start is called before the first frame update
    void Awake()
    {
        SetupSingleton();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
