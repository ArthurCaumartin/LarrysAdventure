using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger");
        if(other.tag == "Player")
            GameManager.instance.ResetCurrentLevel();
    }
}
