using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    public void StartGame()
    {
        Debug.Log("Game is begin");
        menuPanel.SetActive(false);
    }

    public void RestartGame()
    {
        Debug.Log("Game is restarted");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        menuPanel.SetActive(false);
        Application.Quit();
    }
}
