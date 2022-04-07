using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        target = GameObject.Find ("Player");
        weapon = GameObject.Find("Weapon");
        maxHP = 10f;
        currentHP = maxHP;
        damage = weapon.GetComponent<Weapon_Boomerang_Script>().getDamage();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance (transform.position, target.transform.position);
        timer += Time.deltaTime;
        moveCharacter();
        offscreenChecker();
    }

    void moveCharacter()
    {
        if (target != null)
        {
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2 (directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed);
        }
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Weapon")
        {
            currentHP -= damage;
            if(currentHP < 1) {
                Instantiate(xpOrb, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }   
    }

    void OnTriggerStay2D (Collider2D other) {
        if (other.gameObject.tag == "MainCharacter") {
            if (timer > 0.5f && target.GetComponent<Player_HP_Script>().getHealth() > 0f)
            {
                target.GetComponent<Player_HP_Script>().takeDamage(1f);
                timer = 0f;
            } else if (target.GetComponent<Player_HP_Script>().playerCurrentHP <= 0) {
                target.GetComponent<Player_Movement_Script>().enabled = false;
                target.GetComponent<Player_HP_Script>().setVelocity(0 , 0);
            }
        }
    }

    void offscreenChecker() {
        if (distanceToTarget > 30f) {
            Destroy(this.gameObject);
        }
    }
}
