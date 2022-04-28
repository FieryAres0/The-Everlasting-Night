using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HP_Script : MonoBehaviour
{
    public float playerMaxHP;
    public float playerCurrentHP;
    public Rigidbody2D rb;
    public float timer;
    public GameObject SceneChanger;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        playerMaxHP = 100f;
        playerCurrentHP = playerMaxHP;
        SceneChanger = GameObject.Find("SceneChanger");
    }


    void Update()
    {
        if (playerCurrentHP < 1)
        {
            // SceneChanger.GetComponent<Scene_Changer>().ChangeScene("Game Over");
        }
    }
    
    public void takeDamage(float damage)
    {
        playerCurrentHP -= damage;
    }

    public float getHealth()
    {
        return playerCurrentHP;
    }

    public void setVelocity(int x, int y)
    {
        rb.velocity = new Vector2(x, y);
    }

    public float getMaxHealth()
    {
        return playerMaxHP;
    }
}
