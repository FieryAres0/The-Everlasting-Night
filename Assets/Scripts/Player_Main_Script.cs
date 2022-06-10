using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player_Main_Script : MonoBehaviour
{
    public Rigidbody2D rb;
    public float timer;
    public GameObject SceneChanger;
    Health playerHealth = new Health();
    Experiences playerExperiences = new Experiences();
    public float experiences;
    public float maxXP;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        SceneChanger = GameObject.Find("SceneChanger");
    }

    //Check if player is alive, also heal every second
    void Update()
    {
        experiences = playerExperiences.getCurrentXP();
        maxXP = playerExperiences.getMaxXP();

        timer += Time.deltaTime;
        if (getCurrentHealth() <= 0f)
        {
            this.gameObject.GetComponent<Player_Movement_Script>().enabled = false;
            setVelocity(0, 0);
        }
        if (timer > 1)
        {
            heal(1);
            timer = 0;
        }
    }

    //Get current health
    public float getCurrentHealth()
    {
        return playerHealth.getCurrent();
    }

    //Get max health
    public float getMaxHealth()
    {
        return playerHealth.getMax();
    }

    //Increase xp
    public void increasesXP(float amount)
    {
        playerExperiences.addXP(amount);
    }

    //Set the speed of the player
    public void setVelocity(int x, int y)
    {
        rb.velocity = new Vector2(x, y);
    }

    // Detect collision with enemiess
    public void takeDamage(float damage)
    {
        playerHealth.dealDamage(damage);
    }

    //Increase max health
    public void increaseMaxHP(float amount)
    {
        playerHealth.increaseMaxHP(amount);
    }

    //Increase current health
    public void heal(float amount)
    {
        playerHealth.heal(amount);
    }

    //Return currentXP
    public float getCurrentXP()
    {
        return playerExperiences.getCurrentXP();
    }

    //Return required xp
    public float getMaxXP()
    {
        return playerExperiences.getMaxXP();
    }

    //Detect if xp orb is near
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "ExperienceOrbs") {
            playerExperiences.addXP(other.gameObject.GetComponent<XPOrbs_Behavior_Script>().returnXP());
        }
    }

    //Return player's level
    public float getLevel()
    {
        return playerExperiences.getLevel();
    }
}