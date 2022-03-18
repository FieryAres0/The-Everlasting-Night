using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behavior_Script : MonoBehaviour
{
    public GameObject target;
    public Rigidbody2D rb;
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

    }

    void moveCharacter()
    {
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
