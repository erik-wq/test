using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenu;
    public Animator transition;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    void Pause()
    {
        GamePaused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
    public void Resume()
    {
        GamePaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    public void Back()
    {
        Time.timeScale = 1;
        GamePaused = false;
        StartCoroutine(Transition());
    }
    IEnumerator Transition()
    {
        transition.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        App.loader.UnloadScene("Coins collecting");
        App.loader.LoadScene("Menu", true);
    }
}
