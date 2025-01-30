using UnityEngine;
using UnityEngine.UI;

public class ClickUpgradeManager : MonoBehaviour
{
    [Header("Components")]
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    
    [Header("Managers")] 
    public GameManagerB gameManagerB;
    public GameManagerA gameManagerA;
    public PopupManager popupManager;
    
    [Header("Upgrade Prices")]
    public int upgrade1Cost = 100;
    public int upgrade2Cost = 500;
    public int upgrade3Cost = 2500;
    public int upgrade4Cost = 5000;
    public int upgrade5Cost = 10000;

    private bool upgrade1Bought = false;
    private bool upgrade2Bought = false;
    private bool upgrade3Bought = false;
    private bool upgrade4Bought = false;
    private bool upgrade5Bought = false;

    private void Update() {
        if (!upgrade1Bought) button1.interactable = gameManagerB.count >= upgrade1Cost;
        if (!upgrade2Bought) button2.interactable = gameManagerB.count >= upgrade2Cost;
        if (!upgrade3Bought) button3.interactable = gameManagerB.count >= upgrade3Cost;
        if (!upgrade4Bought) button4.interactable = gameManagerB.count >= upgrade4Cost;
        if (!upgrade5Bought) button5.interactable = gameManagerB.count >= upgrade5Cost;
    }

    public void BuyUpgrade1() {
        if (gameManagerB.PurchaseAction(upgrade1Cost)) {
            gameManagerA.clickPower = 10;
            gameManagerB.clickPower = 10;
            upgrade1Bought = true;
            button1.interactable = false;
        }
    }

    public void BuyUpgrade2() {
        if (gameManagerB.PurchaseAction(upgrade2Cost)) {
            gameManagerA.clickPower *= 2;
            gameManagerB.clickPower *= 2;
            upgrade2Bought = true;
            button2.interactable = false;
        }
    }

    public void BuyUpgrade3() {
        if (gameManagerB.PurchaseAction(upgrade3Cost)) {
            upgrade3Bought = true;
            button3.interactable = false;
            popupManager.ActivateGlobalClose();
        }
    }
    
    public void BuyUpgrade4() {
        if (gameManagerB.PurchaseAction(upgrade4Cost)) {
            gameManagerA.clickPower = 100;
            gameManagerB.clickPower = 100;
            upgrade4Bought = true;
            button4.interactable = false;
        }
    }

    public void BuyUpgrade5() {
        if (gameManagerB.PurchaseAction(upgrade5Cost)) {
            gameManagerA.clickPower *= 3;
            gameManagerB.clickPower *= 3;
            upgrade5Bought = true;
            button5.interactable = false;
        }
    }
}
