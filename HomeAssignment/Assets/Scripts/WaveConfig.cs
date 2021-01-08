using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    //the enemy chosen for this wave
    [SerializeField] GameObject enemyPrefab;

    //the path chosen for this wave
    [SerializeField] GameObject pathPrefab;

    //Time between each spawn
    [SerializeField] float timeBetweenSpawns = 0.5f;

    //randomise the time difference
    //[SerializeField] float spawnRandomFactor = 0.3f;

    //numbers of enemies in waves
    [SerializeField] int numberOfEnemies = 5;

    //Enemy movement speed
    [SerializeField] float enemyMoveSpeed = 2f;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }

    public List<Transform> GetWaypoints()
    {
        //each wave can have diff number of waypoints
        var waveWaypoints = new List<Transform>();

        //go into path prefab iterate through child and add to list

        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }

        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }

    //public float GetSpawnRandomFactor() { return spawnRandomFactor; }

    public int GetNumberOfEnemies() { return numberOfEnemies; }

    public float GetEnemyMoveSpeed() { return enemyMoveSpeed; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
