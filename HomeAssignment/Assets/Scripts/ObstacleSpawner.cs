﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    //a list of Waves
    [SerializeField] List<WaveConfig> waveConfigsList;

    [SerializeField] bool looping;

    //always start from position 0 
    int startingWave = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        var currentWave = waveConfigsList[startingWave];

        //loop all waves until looping == true 
        do
        {
            yield return StartCoroutine(SpawnAllWaves());//loops all waves once
        } while (looping);

        //StartCoroutine(SpawnAllWaves());
    }

    // Update is called once per frame
    void Update()
    {

    }

    //coroutines are needed here because we need the yield return to wait for certain functions to run
    //coroutine to spawn all waves
    private IEnumerator SpawnAllWaves()
    {
        foreach (WaveConfig currentWave in waveConfigsList)
        {
            //the coroutine waits for wave to spawn before yielding and going to next wave in list
            yield return StartCoroutine(SpawnAllObstaclesInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllObstaclesInWave(WaveConfig waveToSpawn)
    {

        for (int i = 0; i < waveToSpawn.GetNumberOfObstacles(); i++)
        {
            //spawn Obstacle from wavetoSpawn
            //at the position of the wavepoint(0) of the wavetoSpawn
            var newObstacle = Instantiate(waveToSpawn.GetObstaclePrefab(), waveToSpawn.GetWaypoints()[0].transform.position, Quaternion.identity);

            //the wave will be chosen from the newObstacle and the type of Obstacle it is
            //the wave will be selected from a script not from unity
            newObstacle.GetComponent<ObstaclePathing>().SetWaveConfig(waveToSpawn);//In vain if you're setting wave from SerializedField on Unity but won't cause error.

            yield return new WaitForSeconds(waveToSpawn.GetTimeBetweenSpawns());
        }
    }
}
