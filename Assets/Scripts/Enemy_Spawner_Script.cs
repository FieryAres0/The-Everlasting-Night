using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner_Script : MonoBehaviour
{
    public GameObject objectToSpawn;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2f)
        {
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            timer = 0f;
        }
    }
}
