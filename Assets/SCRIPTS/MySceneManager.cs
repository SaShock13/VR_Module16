using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject environment;
    private void Awake()
    {
        //environment.SetActive(false);
    }

    public void StartGame()
    {
        Debug.Log("Game is begin");
        environment.SetActive(true);
    }

    public void RestartGame()
    {
        Debug.Log("Game is restarted");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        environment.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        menuPanel.SetActive(false);
        Application.Quit();
    }
}
