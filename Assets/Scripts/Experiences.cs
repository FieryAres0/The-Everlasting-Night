using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experiences
{
    private float currentXP;
    private float requiredXP;
    private int level;

    // Constructor
    public Experiences()
    {
        currentXP = 0;
        requiredXP = 100;
        level = 1;
    }

    // Constructor
    public Experiences(float current, float required)
    {
        currentXP = current;
        requiredXP = required;
    }

    // Increase current xp
    public void addXP(float amount)
    {
        currentXP += amount;
        if (currentXP >= requiredXP) {
            currentXP -= requiredXP;
            levelUp();
        }
    }
    
    // Increase level, increase the required xp to level up
    public void levelUp()
    {
        level++;
        float factor = 1;
        for (int i = 0; i < level; i++)
        {
            factor *= 1.05f;
        }
        requiredXP *= factor;
        GameObject SceneChanger = GameObject.Find("SceneChanger");
        SceneChanger.GetComponent<Scene_Changer>().ToggleShop();
    }

    // Return current xp
    public float getCurrentXP()
    {
        return currentXP;
    }

    // Return required xp to level up
    public float getMaxXP()
    {
        return requiredXP;
    }

    // Return current level
    public float getLevel()
    {
        return level;
    }
}
