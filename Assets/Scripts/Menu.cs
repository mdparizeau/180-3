using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Name: Michael Parizeau
/// Date: 12/5/24
/// Description: Manages the replay and quit buttons on the main and gameOver menus
/// </summary>
public class Menu : MonoBehaviour
{
    public GameObject playText;
    public GameObject quitText;

    /// <summary>
    /// Switches the scene to a specified scene index set in the inspector when the ui button for it is pressed
    /// <summary>
    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        // Resets static player variables
        Player.coins = 0;
        Player.level = 0;
        //Player.is_quitter = true;
    }

    // Closes the application
    public void Exit()
    {
        print("Exit Game");
        Application.Quit();
    }
}
