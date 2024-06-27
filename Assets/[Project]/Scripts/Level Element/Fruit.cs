using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fruit : MonoBehaviour
{
    [SerializeField] public GameObject _particle;
    [SerializeField] public int _index;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GameManager.instance.FruitTaken(SceneManager.GetActiveScene().name, _index);
            GameObject newPart = Instantiate(_particle, transform.position, Quaternion.identity);
            Destroy(newPart, newPart.GetComponent<ParticleSystem>().main.duration);
            Destroy(gameObject);
        }
    }
}
