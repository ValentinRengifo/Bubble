using UnityEngine;
public class BulleManagerScript : MonoBehaviour
{
    [Header("Notre \" solde\" de point de bulles")]
    [Min(0)]
    public int bulleScore;
    [Header("Paramètres de Spawn des bulles")]
    public Transform finalPosition;
    public GameObject bubblePrefab;
    [Tooltip("Nombre de bulles générées par seconde. Exemple : 2 -> une bulle toutes les 0.5s, 4 -> une bulle toutes les 0.25s")]
    [Min(0)]
    public float bullesParSeconde = 2f;
    
    private void Start()
    {
        InvokeRepeating(nameof(SpawnBubble), 0f, 1 / bullesParSeconde);
    }

    private void SpawnBubble()
    {
        GameObject newBubble = Instantiate(bubblePrefab, this.transform.position, Quaternion.identity);

        // Récupère le script Bubble et lui transmet des valeurs
        BulleScript bubbleScript = newBubble.GetComponent<BulleScript>();
        if (bubbleScript != null)
        {
            bubbleScript.bulleManager = GetComponent<BulleManagerScript>();
            bubbleScript.finalPosition = finalPosition;
        }
    }
}
