using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    private float currentHealth;
    private float maxHealth;

    //Constructor
    public Health()
    {
        maxHealth = 100f;
        currentHealth = maxHealth;
    }

    //Constructor
    public Health(float current, float max)
    {
        maxHealth = max;
        currentHealth = current;
    }
    

    //Get current health
    public float getCurrent()
    {
        return currentHealth;
    }

    //Get max health
    public float getMax()
    {
        return maxHealth;
    }

    // Reduce current by an amount
    public void dealDamage(float num)
    {
        currentHealth -= num;
    }

    // Increase current by an amount
    public void heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    //Increase max health by an amount
    public void increaseMaxHP(float amount)
    {
        maxHealth += amount;
    }
}
