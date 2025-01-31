using UnityEngine;

public class GameOpener : MonoBehaviour
{
    public GameObject OpenGame;
 
     public void OpenTheGame()
     {
         if (OpenGame != null)
         {
             OpenGame.SetActive(true);
         }
     }
}
