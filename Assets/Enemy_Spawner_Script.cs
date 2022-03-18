using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner_Script : MonoBehaviour
{
    public GameObject objectToSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
