using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public bool isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
    }
    public void Retry()
    {
        SceneManager.LoadScene(1);

    }
    public void Pause()
    {
        if (isPaused = !isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;

        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
