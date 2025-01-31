using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManagerA: MonoBehaviour
{
    [SerializeField] TMP_Text countText;
    [SerializeField] TMP_Text incomeText;
    [SerializeField] StoreUpgradeA[] storeUpgradesA;
    [SerializeField] int updatesPerSecond = 5;
    [SerializeField] public int clickPower = 1;
    
    [HideInInspector] public float count = 0;
    float nextTimeCheck = 1;
    float lastIncomeValue = 0;
    
    private void Start() {
        UpdateUI();
    }

    void Update() {
        if (nextTimeCheck < Time.timeSinceLevelLoad) {
            IdleCalculate();
            nextTimeCheck = Time.timeSinceLevelLoad + (1f / updatesPerSecond);
        }
    }

    void IdleCalculate() {
        float sum = 0;
        foreach (var storeUpgrade in storeUpgradesA) {
            sum += storeUpgrade.CalculateIncomePerSecond();
            storeUpgrade.UpdateUI();
        }
        lastIncomeValue = sum;
        count += sum / updatesPerSecond;
        UpdateUI();
    }
    
    void ClickAction() {
        count += clickPower;
        UpdateUI();
    }

    public bool PurchaseAction(int cost) {
        if (count >= cost) {
            count -= cost;
            UpdateUI();
            return true;
        }
        return false;
    }

    void UpdateUI() {
        countText.text = Mathf.RoundToInt(count).ToString();
        incomeText.text = lastIncomeValue.ToString() + "/s";
    }
}
