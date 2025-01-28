using UnityEngine;

public class ExitUpgradeB : MonoBehaviour
{
    public GameObject UpgradeB;

    public void ExitUpgrade()
    {
        if (UpgradeB != null)
        {
            UpgradeB.SetActive(false);
        }
    }
}
