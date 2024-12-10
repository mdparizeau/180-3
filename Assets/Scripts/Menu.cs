using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * Benjamnin Smith
 * 11/7/2024
 * Changes the scene to the game or quits the game
 */
public class Menu : MonoBehaviour
{
    public GameObject playText;
    public GameObject quitText;

    /// <summary>
    /// Switches the scene to a specified scene index set in the inspector when the ui button for it is pressed
    /// </summary>
    /// <param name="sceneIndex"></param>
    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    // Send the player to the gameOver screen prematurely
    public void Quit(int sceneIndex)
    {
        print("Quit Game");
        SceneManager.LoadScene(sceneIndex);
        Cursor.lockState = CursorLockMode.None;
        GetComponent<Player>().is_quitter = true;
    }
    // Closes the application
    public void Exit()
    {
        print("Exit Game");
        Application.Quit();
    }
}
