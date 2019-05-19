using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void ContinueGame()
    {
        //SceneManager.GetActiveScene.
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene"); 
    }

    public void QuitToMenu()
    {
        Debug.Log("Quit to menu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
