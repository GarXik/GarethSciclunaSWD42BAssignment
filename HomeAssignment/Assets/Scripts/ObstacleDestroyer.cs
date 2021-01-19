using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherObject)//if one of the object itself and hitter is trigger
    {
        Obstacle hasObstacle = otherObject.gameObject.GetComponent<Obstacle>();
        if (hasObstacle != null)//otherObject is an enemy
        {
            print("Enemy Hit");
        }

        Destroy(otherObject.gameObject);
    }
}
