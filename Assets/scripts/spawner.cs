using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public float spawnDelay = 2;
    private float timer = 0;
    public bool canSpawn = true;

    public GameObject slime;

    void Start()
    {
        timer = spawnDelay;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = spawnDelay;
            Spawn();
        }
    }

    void Spawn()
    {
        if (canSpawn){
        Instantiate(slime, transform.position, Quaternion.identity);}
    }

}
