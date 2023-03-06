using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelChecker : MonoBehaviour
{
    public float distance = 8f;
    public bool playerIsHere = false;

    void Update()
    {
        CheckNextToLevel();
        CheckPlayerIsHere();

    }

    private void CheckNextToLevel() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if ((player.transform.position.x - transform.position.x) > distance || (player.transform.position.x - transform.position.x) < -distance || (player.transform.position.y - transform.position.y) > distance || (player.transform.position.y - transform.position.y) < -distance) {
            Destroy(gameObject);
        }
    }

    private void CheckPlayerIsHere() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if ((player.transform.position.x - transform.position.x) < 2.15f && (player.transform.position.x - transform.position.x) > -2.15f && (player.transform.position.y - transform.position.y) < 2.15f && (player.transform.position.y - transform.position.y) > -2.15f) {
            playerIsHere = true;
        } else {
            playerIsHere = false;
        }
    }
}
