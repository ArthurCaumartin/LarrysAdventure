using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private GameObject _particle;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.AddCoin(1);
            GameObject newPart = Instantiate(_particle, transform.position, Quaternion.identity);
            Destroy(newPart, newPart.GetComponent<ParticleSystem>().main.duration);
            Destroy(gameObject);
        }
    }
}
