using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    private PopupManager popupManager;

    public void SetPopupManager(PopupManager manager)
    {
        popupManager = manager;
    }

    public void CloseThisPopup()
    {
        if (popupManager != null)
        {
            popupManager.ClosePopup(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}