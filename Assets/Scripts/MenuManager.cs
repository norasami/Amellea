using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject canvas;
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Play()
    {
        SceneManager.LoadScene("Bedroom1");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Resume()
    {
        canvas.SetActive(false);
        Time.timeScale = 1;
    }
}
