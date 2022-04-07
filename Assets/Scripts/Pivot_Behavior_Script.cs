using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot_Behavior_Script : MonoBehaviour
{
    public Transform pivot;
    public Rigidbody2D rb;
    public GameObject target;
    public Vector3 directionToTarget;
    public float moveSpeed;

    

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find ("Player");
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called 50 frames per second
    void FixedUpdate()
    {
        float distance = Vector3.Distance (pivot.position, target.transform.position);
        rb.transform.Rotate(0, 0, 7.2f, Space.Self);
        pivot.position = target.transform.position;
        
    }
    
    void moveCharacter()
    {
        if (target != null)
        {
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2 (directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed);
        }
    }
}
