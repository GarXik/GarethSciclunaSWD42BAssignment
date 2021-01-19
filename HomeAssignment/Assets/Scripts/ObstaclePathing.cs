using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePathing : MonoBehaviour
{

    //a list of points type Transform
    [SerializeField] List<Transform> waypoints;//This will be filled in line 20 can leave empty in editor

    //[SerializeField] float enemyMoveSpeed = 2f;//We don't need this since we can take speed from waveconfig

    [SerializeField] WaveConfig waveConfig;

    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        //transform.position = waypoints[waypointIndex].transform.position; // this is already being done in the Enemy spawner when we instantiate
    }

    public void SetWaveConfig(WaveConfig waveToSet)
    {
        waveConfig = waveToSet;
    }

    private void EnemyMove()
    {
        // 012                  3-1 = 2
        if (waypointIndex <= waypoints.Count - 1)
        {
            //save the next waypoint as my target position
            var targetPosition = waypoints[waypointIndex].transform.position;

            targetPosition.z = 0f;

            //set the enemy movement per frame
            var enemyMovement = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;

            //move from current position to next position, at the enemy movement speed
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, enemyMovement);

            //if targetposition is reached update the next waypoint
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            //Destroy(gameObject); -- will be done by obstacle destroyer
        }
        //if enemy reaches last waypoint 
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }
}
