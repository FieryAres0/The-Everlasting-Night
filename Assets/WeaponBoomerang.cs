using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBoomerang : MonoBehaviour
{
    public Transform player;
    public GameObject a;
    public GameObject b;
    private Rigidbody2D rb;
    public float rotationSpeed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector3.Distance(a.transform.position, b.transform.position);
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        if (distance >= 30)
        {
            moveWeapon();
        }
        
    }

    void moveWeapon()
    {
        rb.MovePosition(Vector2.right);
    }
}
