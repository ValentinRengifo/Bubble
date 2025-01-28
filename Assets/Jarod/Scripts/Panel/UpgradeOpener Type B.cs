using UnityEngine;

public class UpgradeOpenerTypeB : MonoBehaviour
{
    public GameObject UpgradeB;
 
     public void OpenUpgradeB()
     {
         if (UpgradeB != null)
         {
             UpgradeB.SetActive(true);
         }
     }
}
