using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreText : MonoBehaviour
{
    public GameObject wave;

    // Update is called once per frame
    void Update()
    {
        //change the text to the wave number
        GetComponent<TextMeshProUGUI>().text = "Score: " + wave.GetComponent<EnemySpawner>().wave;
    }
}
