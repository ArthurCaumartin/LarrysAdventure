using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEvent : MonoBehaviour
{
    [SerializeField] private string _tagToTrigger;
    [SerializeField] private UnityEvent _onTriggerEnter;
    [SerializeField] private UnityEvent _onTriggerExit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == _tagToTrigger)
            _onTriggerEnter.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == _tagToTrigger)
            _onTriggerExit.Invoke();
    }
}
