using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class howTo : MonoBehaviour
{
    public GameObject keys;
    public GameObject space;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            keys.SetActive(false);
            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            space.SetActive(false);
        }
    }
}
