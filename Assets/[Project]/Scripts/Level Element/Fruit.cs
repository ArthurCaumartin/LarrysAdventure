using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fruit : MonoBehaviour
{
    [SerializeField] public int _index;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GameManager.instance.FruitTaken(SceneManager.GetActiveScene().name, _index);
            Destroy(gameObject);
        }
    }
}
