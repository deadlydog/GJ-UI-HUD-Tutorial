using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void Play()
    {
        // This starts the game.
        SceneManager.LoadScene("Level1");
    }

    public void Quit()
    {
        // This quits the game.
        Application.Quit();
    }
}
