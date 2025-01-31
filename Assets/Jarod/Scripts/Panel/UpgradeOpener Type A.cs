using UnityEngine;
using UnityEngine.PlayerLoop;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject UpgradeA;

    public void OpenUpgradeA()
    {
        if (UpgradeA != null)
        {
            UpgradeA.SetActive(true);
        }
    }
}
