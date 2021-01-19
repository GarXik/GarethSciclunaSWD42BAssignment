using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int Health = 50;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.7f;
    float xMin, xMax;

    [SerializeField] AudioClip playerHitSound;
    [SerializeField] [Range(0, 1)] float playerHitSoundVolume = 0.75f;

    [SerializeField] AudioClip playerDeathSound;
    [SerializeField] [Range(0, 1)] float playerDeathSoundVolume = 0.75f;

    [SerializeField] GameObject DeathVFX;
    [SerializeField] float explosionDuration = 1f;

    //Camera Border/Boundary
    private void SetupMoveBoundaries()
    {
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
       
        var newXpos = transform.position.x + deltaX;

        newXpos = Mathf.Clamp(newXpos, xMin, xMax);//creates a boundary for x axis

        //move the player car to the new xpos
        this.transform.position = new Vector2(newXpos, transform.position.y);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetupMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        DamageDealer dmg = otherObject.gameObject.GetComponent<DamageDealer>();

        if (!dmg)
        {
            return;
        }

        ProcessHit(dmg);

    }

    private void ProcessHit(DamageDealer dmg)
    {
        Health -= dmg.GetDamage();
        dmg.hit();

        //Play Audio 
        AudioSource.PlayClipAtPoint(playerHitSound, Camera.main.transform.position, playerHitSoundVolume);

        if (Health <= 0)
        {
            Health = 0;
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);

        //create an explosion particle
        GameObject explosion = Instantiate(DeathVFX, transform.position, Quaternion.identity);
        //destroy explosion after 1s
        Destroy(explosion, explosionDuration);

        //Play Audio 
        AudioSource.PlayClipAtPoint(playerDeathSound, Camera.main.transform.position, playerDeathSoundVolume);

        //Finds Level Object in hierarchy and run its method
        //Load GameOver Scene
        FindObjectOfType<Level>().LoadGameOver();
    }

    public int getHealth()
    {
        return Health;
    }
}
