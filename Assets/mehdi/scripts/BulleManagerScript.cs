using System.Collections;
using UnityEngine;

public class BulleManagerScript : MonoBehaviour
{
    [Header("Notre \" solde\" de point de bulles")]
    [Min(0)]
    
    [Header("Paramètres de Spawn des bulles")]
    public Transform finalPosition;
    public GameObject bubblePrefab;
    public int bulleValue = 1;
    public GameManagerA GameManagerA;
    
    [Tooltip("Nombre de bulles générées par seconde. Exemple : 2 -> une bulle toutes les 0.5s, 4 -> une bulle toutes les 0.25s")]
    [Min(0)]
    public float bullesParSeconde = 4f;

    private void Start()
    {
        StartCoroutine(SpawnBubblesCoroutine());
    }

    private IEnumerator SpawnBubblesCoroutine()
    {
        while (true)
        {
            bulleValue = GameManagerA.clickPower;
            SpawnBubble();
            // Calcul d'un temps aléatoire autour de la moyenne
            float meanInterval = 1f / bullesParSeconde;
            float randomInterval = Random.Range(meanInterval * 0.75f, meanInterval * 1.25f); // Variation de ±25%
            
            yield return new WaitForSeconds(randomInterval);
        }
    }

    private void SpawnBubble()
    {
        GameObject newBubble = Instantiate(bubblePrefab, this.transform.position, Quaternion.identity);

        BulleScript bubbleScript = newBubble.GetComponent<BulleScript>();
        if (bubbleScript != null)
        {
            bubbleScript.bulleManager = this;
            bubbleScript.finalPosition = finalPosition;
            bubbleScript.valeur = bulleValue;
            bubbleScript.GameManagerA = GameManagerA;
        }
    }
}