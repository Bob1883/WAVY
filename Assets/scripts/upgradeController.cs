using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class upgradeController : MonoBehaviour
{
    public GameObject playerController; 
    public GameObject playerAttackController;

    //text 
    public GameObject atcUpgradeText;
    public GameObject speedUpgradeText;
    public GameObject healthUpgradeText;
    public GameObject healUpgradeText;
    public GameObject xpText;

    private float playerMaxHealth;

    public float atcUpgradeCost = 10;
    public float speedUpgradeCost = 10;
    public float healthUpgradeCost = 10;
    public float healUpgradeCost = 10;

    void Start()
    {
        playerMaxHealth = playerController.GetComponent<PlayerControler>().health;
    }

    void Update()
    {
        //if 1 is pressed, and upgrade menu is active, upgrade health
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            UpgradeATC();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)){
            UpgradeSpeed();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)){
            UpgradeHealth();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)){
            UpgradeHeal();
        }

        //update text
        xpText.GetComponent<TextMeshProUGUI>().text = "" + playerController.GetComponent<PlayerControler>().Xp;
    }

    public void UpgradeATC()
    {
        if (playerController.GetComponent<PlayerControler>().Xp >= atcUpgradeCost)
        {
            playerAttackController.GetComponent<SwordAttack>().damage += 1;
            playerController.GetComponent<PlayerControler>().Xp -= atcUpgradeCost;
            atcUpgradeCost += 10;
  
            UpdateText();
        }
    }

    public void UpgradeSpeed()
    {
        if (playerController.GetComponent<PlayerControler>().Xp >= speedUpgradeCost)
        {
            playerController.GetComponent<PlayerControler>().moveSpeed += 0.1f;
            playerController.GetComponent<PlayerControler>().Xp -= speedUpgradeCost;
            speedUpgradeCost += 10;

            UpdateText();
        }
    }

    public void UpgradeHealth()
    {
        if (playerController.GetComponent<PlayerControler>().Xp >= healthUpgradeCost)
        {
            playerController.GetComponent<PlayerControler>().maxHealth += 1;
            playerController.GetComponent<PlayerControler>().Xp -= healthUpgradeCost;
            healthUpgradeCost += 10;
            playerMaxHealth += 1;

            UpdateText();
        }
    }

    public void UpgradeHeal()
    {
        if (playerController.GetComponent<PlayerControler>().Xp >= healUpgradeCost)
        {
            playerController.GetComponent<PlayerControler>().health = playerMaxHealth;
            playerController.GetComponent<PlayerControler>().Xp -= healUpgradeCost;
            healUpgradeCost += 10;

            UpdateText();
        }
    }

    public void UpdateText()
    {
        healthUpgradeText.GetComponent<TextMeshProUGUI>().text = "-" + healthUpgradeCost + " XP";
        atcUpgradeText.GetComponent<TextMeshProUGUI>().text = "-" + atcUpgradeCost + " XP";
        speedUpgradeText.GetComponent<TextMeshProUGUI>().text = "-" + speedUpgradeCost + " XP";
        healUpgradeText.GetComponent<TextMeshProUGUI>().text = "-" + healUpgradeCost + " XP";
    }
}
