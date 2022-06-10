using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Behavior_Script : MonoBehaviour
{
    private GameObject target;
    private GameObject weapon;
    private Rigidbody2D rb;
    private Vector3 directionToTarget;
    public float moveSpeed = 3f;
    private float damage;
    private float maxHP;
    private float currentHP;
    public float timer;
    private float distanceToTarget;
    public GameObject xpOrb;

    // Start is called before the first frame update
    // Assigning variables and GameObject
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player");
        weapon = GameObject.Find("Weapon");
        maxHP = 10f * Mathf.Pow(1.05f, target.GetComponent<Player_Main_Script>().getLevel());
        currentHP = maxHP;
        damage = weapon.GetComponent<Weapon_Boomerang_Script>().getDamage();
    }

    // Update is called once per frame
    void Update()
    {
        damage = weapon.GetComponent<Weapon_Boomerang_Script>().getDamage();
        distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
        timer += Time.deltaTime;
        moveCharacter();
        offscreenChecker();
    }

    // Determine's player position and move towards them
    // If player health is 0, pause everything and switch to Game Over scene
    void moveCharacter()
    {
        if (target != null)
        {
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed);
        }
        if (target.GetComponent<Player_Main_Script>().getCurrentHealth() <= 0)
        {
            GameObject weapon = GameObject.Find("Weapon");
            weapon.GetComponent<Weapon_Boomerang_Script>().enabled = false;
            weapon.GetComponentInParent<Pivot_Behavior_Script>().enabled = false;
            GameObject[] spawner = GameObject.FindGameObjectsWithTag("Spawner");
            for (int i = 0; i < spawner.Length; i++) {
                spawner[i].GetComponent<Enemy_Spawner_Script>().enabled = false;
            }
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rb.velocity = new Vector2(0f , 0f);
            this.gameObject.GetComponent<Enemy_Behavior_Script>().enabled = false;
            SceneManager.LoadScene("GameOver");
        }
    }

    // Detects collision with weapon
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Weapon"))
        {
            currentHP -= damage;
            if (currentHP < 1)
            {
                Instantiate(xpOrb, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }

    // Check if enemy is far away, delete them if they are
    void offscreenChecker()
    {
        if (distanceToTarget > 40f)
        {
            Destroy(this.gameObject);
        }
    }

    // check if collide with player, deal damage collided
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("MainCharacter"))
        {
            if (timer > 0.5f && target.GetComponent<Player_Main_Script>().getCurrentHealth() > 0f)
            {
                target.GetComponent<Player_Main_Script>().takeDamage(1f);
                timer = 0f;
            }
        }
    }
}
