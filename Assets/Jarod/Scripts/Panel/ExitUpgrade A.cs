using UnityEngine;

public class ExitUpgrade : MonoBehaviour
{
    public GameObject UpgradeA;

    public void ExitUpgradeA()
    {
        if (UpgradeA != null)
        {
            UpgradeA.SetActive(false);
        }
    }
}
