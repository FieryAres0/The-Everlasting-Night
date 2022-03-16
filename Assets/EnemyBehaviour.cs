using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // public Transform player;
    public GameObject target;
    public Rigidbody2D rb;
    // public Vector2 movement;
    public Vector3 directionToTarget;
    public float moveSpeed = 3f;
    

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find ("Player");
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // Vector3 direction = player.position - transform.position;
        // // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // // rb.rotation = angle;
        // direction.Normalize();
        // movement = direction;

    }

    void moveCharacter()
    {
        // rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        if (target != null)
        {
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2 (directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed);
        }
    }

    void FixedUpdate()
    {
        moveCharacter();
    }
}
