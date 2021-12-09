using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   public void RestartButton()
    {
        SceneManager.LoadScene("Enemy Movement testing in game");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
