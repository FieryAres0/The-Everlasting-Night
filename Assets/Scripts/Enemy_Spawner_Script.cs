using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Enemy_Spawner_Script : MonoBehaviour
{
    public GameObject objectToSpawn;
    // spawnRate is in enemies per minutes
    public float spawnRate;
    public float timer;
    public float enemyCount;
    public float maxSpawnAmount;
    public float timer2;
    public StreamReader FileReader;
    

    // Start is called before the first frame update
    void Start()
    {
        FileReader = new StreamReader("EnemySpawnRate.txt");
        spawnRate = float.Parse(FileReader.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);
        enemyCount = 0f;
        maxSpawnAmount = 150f;
        timer = 0f;
        timer2 = 0f;
    }

    // Update is called once per frame
    // Spawn enemy on timer
    void Update()
    {
        timer2 += Time.deltaTime;
        timer += Time.deltaTime;
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (timer >= spawnRateSPE() && enemyCount < maxSpawnAmount)
        {
            enemyCount++;
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            timer = 0f;
        }

        if (timer2 >= 60f)
        {
            spawnRate = float.Parse(FileReader.ReadLine(), CultureInfo.InvariantCulture.NumberFormat);
            timer2 = 0f;
        }
    }

    // spawn rate is convert into seconds per enemy
    float spawnRateSPE()
    {
        return (60f / spawnRate) * 2f;
    }
    
}
