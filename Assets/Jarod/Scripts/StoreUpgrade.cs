using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreUpgrade : MonoBehaviour
{
    [Header("Components")]
    public TMP_Text priceText;
    public TMP_Text incomeInfoText;
    public Button button;
    
    [Header("Generator values")]
    public int startPrice = 15;
    public float upgradePriceMultiplier;
    public float bubblesPerUpgrade = 0.1f;

    [Header("Managers")] 
    public GameManager gameManager;
    
    int level = 0;

    public void ClickAction() {
        int price = CalculatePrice();
        bool purchaseSuccess = gameManager.PurchaseAction(price);
        if (purchaseSuccess) {
            level++;
            UpdateUI();
        }
    }
    
    private void Start() {
        UpdateUI();
    }
    
    public void UpdateUI() {
        priceText.text = CalculatePrice().ToString();
        incomeInfoText.text = level.ToString() + " x " + bubblesPerUpgrade + "/s";
        bool canAfford = gameManager.count >= CalculatePrice();
        button.interactable = canAfford;
    }

    int CalculatePrice() {
        int Price = Mathf.RoundToInt(startPrice * Mathf.Pow(upgradePriceMultiplier, level));
        return Price;
    }
    public float CalculateIncomePerSecond() {
        return bubblesPerUpgrade * level;
    }
}
