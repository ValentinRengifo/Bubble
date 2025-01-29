using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreUpgradeB : MonoBehaviour
{
    [Header("Components")]
    public TMP_Text priceText;
    public TMP_Text incomeInfoText;
    public Button button;
    
    [Header("Generator values")]
    public int startPrice = 15;
    public float upgradePriceMultiplier;
    public float pubsPerUpgrade = 0.1f;

    [Header("Managers")] 
    public GameManagerB gameManagerB;
    
    int level = 0;

    public void ClickAction() {
        int price = CalculatePrice();
        bool purchaseSuccess = gameManagerB.PurchaseAction(price);
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
        incomeInfoText.text = level.ToString() + " x " + pubsPerUpgrade + "/s";
        bool canAfford = gameManagerB.count >= CalculatePrice();
        button.interactable = canAfford;
    }

    int CalculatePrice() {
        int Price = Mathf.RoundToInt(startPrice * Mathf.Pow(upgradePriceMultiplier, level));
        return Price;
    }
    public float CalculateIncomePerSecond() {
        return pubsPerUpgrade * level;
    }
}
