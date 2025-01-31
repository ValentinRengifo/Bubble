using TMPro;
using UnityEngine;

public class GameManagerB : MonoBehaviour
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
            Debug.Log(storeUpgrade.isActiveAndEnabled);
            if(storeUpgrade.isActiveAndEnabled)
            {
                storeUpgrade.UpdateUI();
            }
        }
        lastIncomeValue = sum;
        count += sum / updatesPerSecond;
        UpdateUI();
    }

    public void ClickAction() {
        count += clickPower;
        UpdateUI();
    }
    
    public void PopupClickAction() {
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
    
    public void PopupClickActionMultiple(int popupCount) {
        count += clickPower * popupCount;
        UpdateUI();
    }
    
    void UpdateUI() {
        countText.text = Mathf.RoundToInt(count).ToString();
        incomeText.text = lastIncomeValue.ToString() + "/s";
    }
}