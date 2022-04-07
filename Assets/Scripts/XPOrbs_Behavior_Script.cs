using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPOrbs_Behavior_Script : MonoBehaviour
{
    public GameObject target;
    private float distanceToTarget;
    public Vector3 directionToTarget;
    private Rigidbody2D rb;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance (transform.position, target.transform.position);
        directionToTarget = (target.transform.position - transform.position).normalized;
        if (distanceToTarget < 5f) {
            rb.velocity = new Vector2 (directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed);
        }
    }
    
    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "MainCharacter") {
            Destroy(this.gameObject);
        }
    }
}
