using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public GameObject popupPrefab; // Préfabriqué du popup
    public Transform popupContainer; // Conteneur pour accumuler les pop-ups

    public float spawnInterval = 5f; // Intervalle de départ entre les spawns de pop-ups
    public float minSpawnInterval = 1f; // Intervalle minimum entre les spawns
    public float spawnSpeedIncrease = 0.1f; // Vitesse à laquelle l'intervalle diminue

    private float timer = 0f; // Temps écoulé pour gérer les spawns

    private void Update()
    {
        // Met à jour le minuteur
        timer += Time.deltaTime;

        // Si le temps écoulé dépasse l'intervalle, générer un nouveau pop-up
        if (timer >= spawnInterval)
        {
            ShowPopup("Ceci est un message par défaut !"); // Affiche un message fixe
            timer = 0f; // Réinitialiser le minuteur

            // Réduire l'intervalle progressivement pour augmenter la fréquence
            if (spawnInterval > minSpawnInterval)
            {
                spawnInterval -= spawnSpeedIncrease;
            }
        }
    }

    // Méthode pour afficher un pop-up
    public void ShowPopup(string message)
    {
        // Créer une nouvelle instance du pop-up
        GameObject newPopup = Instantiate(popupPrefab, popupContainer);
        

        // Modifier le texte du pop-up
        Text popupText = newPopup.GetComponentInChildren<Text>();
        if (popupText != null)
        {
            popupText.text = message;
        }

        // Configurer le bouton "Fermer"
        Button closeButton = newPopup.GetComponentInChildren<Button>();
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(() => ClosePopup(newPopup));
        }

        // Activer le pop-up
        newPopup.SetActive(true);
    }

    // Méthode pour fermer un pop-up
    public void ClosePopup(GameObject popup)
    {
        popup.SetActive(false); // Désactiver le pop-up
        Destroy(popup); // Détruire le GameObject pour libérer de la mémoire
    }
}
