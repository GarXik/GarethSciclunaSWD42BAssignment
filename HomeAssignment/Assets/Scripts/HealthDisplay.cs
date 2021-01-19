using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    Player player;
    Text healthText;
    Slider healthBar;
    int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();
        player = FindObjectOfType<Player>();
        healthBar = FindObjectOfType<Slider>();
        maxHealth = 50;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = player.getHealth().ToString() + " HP";
        float result = (float)player.getHealth() / (float)maxHealth;
        healthBar.value = result;

    }
}
