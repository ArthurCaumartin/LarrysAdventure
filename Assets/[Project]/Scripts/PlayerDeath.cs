using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
     // Méthode appelée lorsqu'il y a une collision (pour les jeux 3D)
    private void OnCollisionEnter(Collision collision)
    {
        // Affiche un message de debug indiquant qu'une collision a été détectée
        Debug.Log("Collision détectée avec : " + collision.gameObject.name);

        // Vérifie si l'objet avec lequel le joueur entre en collision a le tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Affiche un message de debug indiquant que l'objet est un ennemi
            Debug.Log("Collision avec un ennemi détectée. Rechargement de la scène...");

            // Relance la scène actuelle
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Méthode appelée lorsqu'il y a une collision (pour les jeux 2D)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Affiche un message de debug indiquant qu'une collision a été détectée
        Debug.Log("Collision 2D détectée avec : " + collision.gameObject.name);

        // Vérifie si l'objet avec lequel le joueur entre en collision a le tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Affiche un message de debug indiquant que l'objet est un ennemi
            Debug.Log("Collision 2D avec un ennemi détectée. Rechargement de la scène...");

            // Relance la scène actuelle
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
