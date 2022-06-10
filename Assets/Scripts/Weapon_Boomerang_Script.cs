using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Boomerang_Script : MonoBehaviour
{
    public Rigidbody2D rb;
    private float damage;

    void Start()
    {
        damage = 5f;
        rb = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.transform.Rotate(0, 0, 7.2f, Space.Self);
    }

    public float getDamage() {
        return damage;
    }

    public void increaseDamage(float amount)
    {
        damage += amount;
    }
}
