using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner_Script : MonoBehaviour
{
    public GameObject objectToSpawn;
    private float timer;
    public float enemyCount;
    public float maxSpawnAmount;

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = 0f;
        maxSpawnAmount = 50f;
        timer = 0f;
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (timer > 2f && enemyCount < maxSpawnAmount)
        {
            enemyCount++;
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            timer = 0f;
        }
    }
}
