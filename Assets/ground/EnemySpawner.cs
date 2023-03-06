using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public float slime2SpawnChance = 0;
    public bool canSpawnBoss = false;
    public float spawn_delay = 2;
    public bool canSpawn = true;
    public int wave = 1;
    private float waveTimer = 0;
    private float timer = 0;


    public GameObject slime;
    public GameObject slime2;
    public GameObject slimeBoss;
    public GameObject waveText;

    void Start()
    {
        timer = spawn_delay;
    }

    void Update()
    {
        if (canSpawn){  
    
        timer -= Time.deltaTime;
        waveTimer += Time.deltaTime;

        if (timer <= 0 && GameObject.FindGameObjectsWithTag("Enemy").Length < 150)
        {
            timer = spawn_delay;
            Spawn();
        }

        if (waveTimer >= 15)
        {
            wave++;
            waveTimer = 0;
            spawn_delay -= 0.1f;
            
            waveText.GetComponent<TextMeshProUGUI>().text = "Wave: " + wave;

            if (wave % 5 == 0 && slime2SpawnChance < 1){
                slime2SpawnChance += 0.1f;
            } 
            if (wave % 15 == 0){
                canSpawnBoss = true;
            }
            if (wave < 5){
                slime2SpawnChance = 0f;
            }
        }
        }
    }

    void Spawn()
    {
        //spawn enemy somewhere next to player but not closer than 5 units
        //check also so it doesnt spawn on a object with tag "objekt"
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        //find a random position
        float posx = Random.Range(-15, 15);
        float posy = Random.Range(-15, 15);

        if (posx < 5 && posx > -5)
        {
            posx = 5;
        } else if (posy > -5 && posy < 5)
        {
            posy = -5;
        }

        Vector3 spawnPosition = new Vector3(player.transform.position.x + posx, player.transform.position.y + posy, 0);

        //spawn enemy boss if wave is divisible by 15 or if wave is more then 50 
        if (canSpawnBoss || wave > 50)
        {
            Instantiate(slimeBoss, spawnPosition, Quaternion.identity);
            canSpawnBoss = false;
        } else if (Random.Range(0f, 1f) < slime2SpawnChance)
        {
            Instantiate(slime2, spawnPosition, Quaternion.identity);
        } else
        {
            Instantiate(slime, spawnPosition, Quaternion.identity);
        }
    }
}