using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource _source;
    [SerializeField] AudioClip _coinPickup;


    public void PlayCoinSfx()
    {
        _source.pitch = Random.Range(0.9f, 1.5f);
        _source.PlayOneShot(_coinPickup);
    }
}
