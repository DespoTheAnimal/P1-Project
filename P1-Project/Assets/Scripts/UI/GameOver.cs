using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour

{
   public void RestartButton()
    {
        SceneManager.LoadScene("HomeBase1");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
