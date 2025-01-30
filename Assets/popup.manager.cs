using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopupManager : MonoBehaviour
{
    public GameObject popupPrefab; // Prefab du pop-up
    public Transform popupContainer; // Conteneur des pop-ups
    public Button panelButton; // Bouton global pour fermer toutes les pop-ups
    public GameManagerB gameManagerB;

    public Sprite[] popupImages; // Liste des images à afficher

    public float minSpawnTime = 1f;
    public float maxSpawnTime = 15f;
    public int maxPopupsAtOnce = 5;

    private System.Random random = new System.Random();

    private void Start()
    {
        if (panelButton != null)
        {
            panelButton.gameObject.SetActive(false);
        }

        StartCoroutine(SpawnPopupsRandomly());
    }

    private IEnumerator SpawnPopupsRandomly()
    {
        while (true)
        {
            float randomWaitTime = Random.Range(minSpawnTime, maxSpawnTime);
            int popupsToSpawn = Random.Range(1, maxPopupsAtOnce + 1);

            bool triggerMassPopup = random.Next(0, 100) == 0;
            if (triggerMassPopup)
            {
                popupsToSpawn = Random.Range(10, 21);
            }

            yield return new WaitForSeconds(randomWaitTime);

            for (int i = 0; i < popupsToSpawn; i++)
            {
                ShowPopup();

                float delay = Random.Range(0.05f, 0.2f);
                yield return new WaitForSeconds(delay);
            }
        }
    }

    public void ShowPopup()
    {
        if (popupImages.Length == 0) return;

        GameObject newPopup = Instantiate(popupPrefab, popupContainer);
        newPopup.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        newPopup.transform.localPosition = GetRandomCanvasPosition();

        Image popupImage = newPopup.GetComponentInChildren<Image>();
        if (popupImage != null)
        {
            popupImage.sprite = popupImages[Random.Range(0, popupImages.Length)];
        }

        Button closeButton = newPopup.GetComponentInChildren<Button>();
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(() => ClosePopup(newPopup));
        }

        newPopup.SetActive(true);
        UpdateGlobalCloseState();
    }

    private Vector3 GetRandomCanvasPosition()
    {
        RectTransform canvasRect = popupContainer.GetComponent<RectTransform>();
        RectTransform popupRect = popupPrefab.GetComponent<RectTransform>();

        float canvasWidth = canvasRect.rect.width;
        float canvasHeight = canvasRect.rect.height;
        float popupWidth = popupRect.rect.width * popupRect.localScale.x;
        float popupHeight = popupRect.rect.height * popupRect.localScale.y;

        float minX = -canvasWidth / 2 + popupWidth / 2;
        float maxX = canvasWidth / 2 - popupWidth / 2;
        float minY = -canvasHeight / 2 + popupHeight / 2;
        float maxY = canvasHeight / 2 - popupHeight / 2;

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        return new Vector3(randomX, randomY, 0);
    }

    public void ClosePopup(GameObject popup)
    {
        Destroy(popup);
        gameManagerB.PopupClickAction();
        UpdateGlobalCloseState();
    }

    public void CloseAllPopups()
    {
        int popupCount = popupContainer.childCount;
        if (popupCount > 0)
        {
            foreach (Transform child in popupContainer)
            {
                Destroy(child.gameObject);
            }
            gameManagerB.PopupClickActionMultiple(popupCount);
        }

        UpdateGlobalCloseState();
    }

    private void UpdateGlobalCloseState()
    {
        if (panelButton != null)
        {
            panelButton.gameObject.SetActive(popupContainer.childCount > 0);
        }
    }
    
    public void ActivateGlobalClose()
    {
        if (panelButton != null)
        {
            panelButton.onClick.AddListener(CloseAllPopups);
            UpdateGlobalCloseState();
        }
    }
}
