using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "obstacle Wave Config")]
public class WaveConfig : ScriptableObject
{
    //the obstacle chosen for this wave
    [SerializeField] GameObject obstaclePrefab;

    //the path chosen for this wave
    [SerializeField] GameObject pathPrefab;

    //Time between each spawn
    [SerializeField] float timeBetweenSpawns = 0.5f;

    //numbers of Obstacles in waves
    [SerializeField] int numberOfObstacles = 5;

    //obstacle movement speed
    [SerializeField] float obstacleMoveSpeed = 2f;

    public GameObject GetObstaclePrefab() { return obstaclePrefab; }

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

    public int GetNumberOfObstacles() { return numberOfObstacles; }

    public float GetObstacleMoveSpeed() { return obstacleMoveSpeed; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
