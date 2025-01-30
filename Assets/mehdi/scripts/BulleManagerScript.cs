using UnityEngine;

namespace mehdi.scripts
{
    public class BulleManagerScript : MonoBehaviour
    {
        public int bulleScore;
        public Transform finalPosition;

        public GameObject bubblePrefab;

        private void Start()
        {
            InvokeRepeating(nameof(SpawnBubble), 0f, 0.50f);
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
}
