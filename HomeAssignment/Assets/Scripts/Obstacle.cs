using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] bool canShoot = false;//if true obstacle will shoot
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float enemyLaserSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    //count down shot counter to 0 and shoot
    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0f)
        {
            EnemyFire();

            //reset Shotcounter after every fire
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void EnemyFire()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity); // place laserprefab on player ship position

        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -enemyLaserSpeed);// this will make it shoot to the y-axis at a speed of 15
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            CountDownAndShoot();
        }
    }
}
