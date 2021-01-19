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

    [SerializeField] GameObject DeathVFX;
    [SerializeField] float explosionDuration = 1f;

    [SerializeField] AudioClip obstacleHitSound;
    [SerializeField] [Range(0, 1)] float obstacleHitSoundVolume = 0.75f;

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
            ObstacleFire();

            //reset Shotcounter after every fire
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void ObstacleFire()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity); 

        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -enemyLaserSpeed);// this will make it shoot to the y-axis at a speed of 15
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        Player plr = otherObject.gameObject.GetComponent<Player>();

        //if obstacle hits player destroy it
        if (plr != null)
        {
            ObstacleDie();
        }

    }

    private void ObstacleDie()
    {
        Destroy(gameObject);
        //create an explosion particle
        GameObject explosion = Instantiate(DeathVFX, transform.position, Quaternion.identity);
        //destroy explosion after 1s
        Destroy(explosion, explosionDuration);

        //Play Audio
        AudioSource.PlayClipAtPoint(obstacleHitSound, Camera.main.transform.position, obstacleHitSoundVolume);

        //FindObjectOfType<GameSession>().AddToScore(scoreValue);
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
