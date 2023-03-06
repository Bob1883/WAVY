using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIControler : MonoBehaviour
{
    public GameObject upgradeMenu;
    public GameObject playerController;
    public GameObject playerAttackController;
    public GameObject enemyController;
    public GameObject enemySpawner;
    public GameObject xpText;
    public GameObject deathScreen;

    public bool canOpenMenu = false;

    void Update(){   

        if (Input.GetKeyDown(KeyCode.E) && canOpenMenu){ 
            if (upgradeMenu.activeSelf)
            {    
                    upgradeMenu.SetActive(false);
                    playerController.GetComponent<PlayerControler>().canMove = true;
                    playerController.GetComponent<PlayerControler>().canAttack = true;

                    enemyController.GetComponent<Enemy>().canMove = true;
                    enemyController.GetComponent<Enemy>().canAttack = true;

                    foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
                    {
                        enemy.GetComponent<Enemy>().canMove = true;
                        enemy.GetComponent<Enemy>().canAttack = true;
                    }

                    enemySpawner.GetComponent<EnemySpawner>().canSpawn = true;
 
            } else {
                    upgradeMenu.SetActive(true);
                    playerController.GetComponent<PlayerControler>().canMove = false;
                    playerController.GetComponent<PlayerControler>().canAttack = false;

                    enemyController.GetComponent<Enemy>().canMove = false;
                    enemyController.GetComponent<Enemy>().canAttack = false;

                    foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
                    {
                        enemy.GetComponent<Enemy>().canMove = false;
                        enemy.GetComponent<Enemy>().canAttack = false;
                    }

                    enemySpawner.GetComponent<EnemySpawner>().canSpawn = false;

                    xpText.GetComponent<TextMeshProUGUI>().text = "" + playerController.GetComponent<PlayerControler>().Xp;
            }
        }
    }

    void RestartGame()
    {
        //destroy all levels
        foreach (GameObject level in GameObject.FindGameObjectsWithTag("Level"))
        {
            Destroy(level);
        }
        playerController.GetComponent<PlayerControler>().transform.position = new Vector3(0,0,0);
        playerController.GetComponent<PlayerControler>().health = 10;
        playerController.GetComponent<PlayerControler>().Xp = 0;
        playerController.GetComponent<PlayerControler>().moveSpeed = 1f;
        playerAttackController.GetComponent<SwordAttack>().damage = 1;
        upgradeMenu.GetComponent<upgradeController>().atcUpgradeCost = 10;
        upgradeMenu.GetComponent<upgradeController>().speedUpgradeCost = 10;
        upgradeMenu.GetComponent<upgradeController>().healthUpgradeCost = 10;
        upgradeMenu.GetComponent<upgradeController>().healUpgradeCost = 10;
        deathScreen.SetActive(false);
        enemySpawner.GetComponent<levelSpawner>().SpawnInitialLevels();
        playerController.GetComponent<PlayerControler>().StartPlayerAnimation();
        canOpenMenu = true;
        enemySpawner.GetComponent<EnemySpawner>().canSpawn = true;
        playerController.GetComponent<PlayerControler>().canMove = true;
        playerController.GetComponent<PlayerControler>().canAttack = true;
        upgradeMenu.GetComponent<upgradeController>().UpdateText();
        enemySpawner.GetComponent<EnemySpawner>().spawn_delay = 2;
        enemySpawner.GetComponent<EnemySpawner>().wave = 1;
    }
}
