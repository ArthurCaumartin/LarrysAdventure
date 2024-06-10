using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    // Dictionnaires pour stocker les boutons et les objets associés
    private Dictionary<Button, GameObject> buttonActivateMap;
    private Dictionary<Button, GameObject> buttonDeactivateMap;
    private Dictionary<Button, string> buttonSceneMap;

    // Listes des boutons et objets à configurer via l'éditeur Unity
    public List<Button> activateButtons;
    public List<GameObject> objectsToActivate;

    public List<Button> deactivateButtons;
    public List<GameObject> objectsToDeactivate;

    // Listes des boutons pour changer de scène et les noms des scènes
    public List<Button> sceneChangeButtons;
    public List<string> scenesToLoad;

    // Bouton pour quitter le jeu
    public Button quitGameButton;

    void Start()
    {
        // Initialiser les dictionnaires
        buttonActivateMap = new Dictionary<Button, GameObject>();
        buttonDeactivateMap = new Dictionary<Button, GameObject>();
        buttonSceneMap = new Dictionary<Button, string>();

        // Vérifier si les listes de boutons et d'objets sont de la même longueur pour l'activation
        if (activateButtons.Count != objectsToActivate.Count)
        {
            Debug.LogError("Les listes de boutons et d'objets pour l'activation ne correspondent pas en longueur!");
            return;
        }

        // Vérifier si les listes de boutons et d'objets sont de la même longueur pour la désactivation
        if (deactivateButtons.Count != objectsToDeactivate.Count)
        {
            Debug.LogError("Les listes de boutons et d'objets pour la désactivation ne correspondent pas en longueur!");
            return;
        }

        // Vérifier si les listes de boutons et de scènes sont de la même longueur pour le changement de scène
        if (sceneChangeButtons.Count != scenesToLoad.Count)
        {
            Debug.LogError("Les listes de boutons et de scènes pour le changement de scène ne correspondent pas en longueur!");
            return;
        }

        // Associer chaque bouton à un objet pour l'activation et ajouter un listener pour chaque bouton
        for (int i = 0; i < activateButtons.Count; i++)
        {
            Button button = activateButtons[i];
            GameObject obj = objectsToActivate[i];

            buttonActivateMap[button] = obj;

            // Ajouter un listener pour le bouton
            button.onClick.AddListener(() => OnActivateButtonClick(button));
        }

        // Associer chaque bouton à un objet pour la désactivation et ajouter un listener pour chaque bouton
        for (int i = 0; i < deactivateButtons.Count; i++)
        {
            Button button = deactivateButtons[i];
            GameObject obj = objectsToDeactivate[i];

            buttonDeactivateMap[button] = obj;

            // Ajouter un listener pour le bouton
            button.onClick.AddListener(() => OnDeactivateButtonClick(button));
        }

        // Associer chaque bouton à une scène et ajouter un listener pour chaque bouton
        for (int i = 0; i < sceneChangeButtons.Count; i++)
        {
            Button button = sceneChangeButtons[i];
            string sceneName = scenesToLoad[i];

            buttonSceneMap[button] = sceneName;

            // Ajouter un listener pour le bouton
            button.onClick.AddListener(() => OnChangeSceneButtonClick(button));
        }

        // Ajouter le listener pour le bouton de sortie
        if (quitGameButton != null)
        {
            quitGameButton.onClick.AddListener(QuitGame);
        }
    }

    // Fonction appelée lors du clic sur un bouton pour l'activation
    void OnActivateButtonClick(Button button)
    {
        if (buttonActivateMap.TryGetValue(button, out GameObject obj))
        {
            // Activer l'objet associé
            obj.SetActive(true);
        }
    }

    // Fonction appelée lors du clic sur un bouton pour la désactivation
    void OnDeactivateButtonClick(Button button)
    {
        if (buttonDeactivateMap.TryGetValue(button, out GameObject obj))
        {
            // Désactiver l'objet associé
            obj.SetActive(false);
        }
    }

    // Fonction appelée lors du clic sur un bouton pour changer de scène
    void OnChangeSceneButtonClick(Button button)
    {
        if (buttonSceneMap.TryGetValue(button, out string sceneName))
        {
            // Charger la scène associée
            SceneManager.LoadScene(sceneName);
        }
    }

    // Fonction pour quitter le jeu
    void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        // Si nous sommes dans l'éditeur, arrêter le mode de jeu
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
