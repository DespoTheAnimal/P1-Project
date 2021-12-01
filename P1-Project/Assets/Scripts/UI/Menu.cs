using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    /// The menus in the menu

    public GameObject MenuButtons;


    /// <summary>
    /// The Menu buttons get activated when the scene starts
    /// </summary>
    private void Start()
    {
        MenuButtons.SetActive(true);

    }
    /// <summary>
    /// The First game scene starts when pressing the game button
    /// </summary>
    public void OnStartButton()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Tge application shuts down
    /// </summary>
    public void OnQuitButton()
    {
        Application.Quit();
    }
  
    /// <summary>
    /// If the escape button is pressed the game also shuts down
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
