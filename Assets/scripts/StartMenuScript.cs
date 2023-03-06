using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuScript : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject enemySpawner;
    public GameObject playerController;
    public GameObject upgradeMenu;
    public GameObject slime;

    public void StartGame()
    {
        startMenu.SetActive(false);
        enemySpawner.GetComponent<EnemySpawner>().canSpawn = true;
        playerController.GetComponent<PlayerControler>().canMove = true;
        playerController.GetComponent<PlayerControler>().canAttack = true;
        upgradeMenu.GetComponent<UIControler>().canOpenMenu = true;
        slime.GetComponent<Enemy>().canMove = true;
    }
}
