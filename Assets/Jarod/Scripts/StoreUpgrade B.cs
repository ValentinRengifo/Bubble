using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
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

    private GameManagerA gameManagerA;
    
    int level = 0;

    
    private void Awake()
    {
        gameManagerA = FindFirstObjectByType<GameManagerA>();
    }
    
    public void ClickAction() {
        int price = CalculatePrice();
        if (price <= gameManagerA.count) {
            gameManagerA.PurchaseAction(price);
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
        bool canAfford = gameManagerA.count >= CalculatePrice();
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
