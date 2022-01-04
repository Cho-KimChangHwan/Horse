using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneJump : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void LoadFarmScene()
   {
       SceneManager.LoadScene(0);
   }
   public void LoadShopScene()
   {
       SceneManager.LoadScene(1);
   }
   public void LoadRacingScene()
   {
       SceneManager.LoadScene(2);
   }
   public void LoadContestScene()
   {
       SceneManager.LoadScene(3);
   }
   public void LoadStartScene()
   {
       SceneManager.LoadScene(4);
   }
}
