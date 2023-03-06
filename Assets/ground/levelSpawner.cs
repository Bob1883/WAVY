using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSpawner : MonoBehaviour
{
    public GameObject[] levelPrefabs;
    public float maxLevels = 9;
    public GameObject player;

    private GameObject[,] levels;

    void Start()
    {
        SpawnInitialLevels();
    }

    void Update()
    {
        SpawnNewLevels();
    }

    public void SpawnInitialLevels()
    {
        Vector3[] spawnPositions = new Vector3[] {
            new Vector3(0, 0, 0),
            new Vector3(0, 4.3f, 0),
            new Vector3(4.15f, 4.3f, 0),
            new Vector3(4.15f, 0, 0),
            new Vector3(4.15f, -4.3f, 0),
            new Vector3(0, -4.3f, 0),
            new Vector3(-4.15f, -4.3f, 0),
            new Vector3(-4.15f, 0, 0),
            new Vector3(-4.15f, 4.3f, 0)
        };

        for (int i = 0; i < spawnPositions.Length; i++) {
            if (i == 0) {
                GameObject newLevel = Instantiate(levelPrefabs[0], spawnPositions[i], Quaternion.identity);
                newLevel.transform.SetParent(transform);
                newLevel.GetComponent<levelChecker>().playerIsHere = true;
            } else
            {
                int randomLevel = Random.Range(0, 2);

                if (randomLevel == 0) {
                    randomLevel = 0;
                } else {
                    randomLevel = Random.Range(1, levelPrefabs.Length);
                }

                GameObject newLevel = Instantiate(levelPrefabs[randomLevel], spawnPositions[i], Quaternion.identity);
                newLevel.transform.SetParent(transform);
            }
        }
    }

    private void SpawnNewLevels()
    {
        GameObject playerLevel = null;
        foreach (GameObject level in GameObject.FindGameObjectsWithTag("Level"))
        {
            if (level.GetComponent<levelChecker>().playerIsHere)
            {
                playerLevel = level;
            }
        }

        Vector3[] spawnPositions = new Vector3[] {
            new Vector3(playerLevel.transform.position.x, playerLevel.transform.position.y + 4.3f, 0),
            new Vector3(playerLevel.transform.position.x + 4.15f, playerLevel.transform.position.y + 4.3f, 0),
            new Vector3(playerLevel.transform.position.x + 4.15f, playerLevel.transform.position.y, 0),
            new Vector3(playerLevel.transform.position.x + 4.15f, playerLevel.transform.position.y - 4.3f, 0),
            new Vector3(playerLevel.transform.position.x, playerLevel.transform.position.y - 4.3f, 0),
            new Vector3(playerLevel.transform.position.x - 4.15f, playerLevel.transform.position.y - 4.3f, 0),
            new Vector3(playerLevel.transform.position.x - 4.15f, playerLevel.transform.position.y, 0),
            new Vector3(playerLevel.transform.position.x - 4.15f, playerLevel.transform.position.y + 4.3f, 0)
        };

        bool[] levelExists = new bool[] {
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false
        };

        foreach (GameObject level in GameObject.FindGameObjectsWithTag("Level"))
        {
            for (int i = 0; i < spawnPositions.Length; i++)
            {
                if (level.transform.position == spawnPositions[i])
                {
                    levelExists[i] = true;
                }
            }
        }

        for (int i = 0; i < levelExists.Length; i++)
        {
            if (!levelExists[i])
            {
                int randomLevel = Random.Range(0, 2);

                if (randomLevel == 0)
                {
                    randomLevel = 0;
                }
                else
                {
                    randomLevel = Random.Range(1, levelPrefabs.Length);
                }

                GameObject newLevel = Instantiate(levelPrefabs[randomLevel], spawnPositions[i], Quaternion.identity);
                newLevel.transform.SetParent(transform);
            }
        }
    }
}