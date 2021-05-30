using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : BaseScreen
{
    public Animator transition;
    public void StartGame()
    {
        StartCoroutine(Transition());
    }
    public void ShowOptions()
    {
        Hide();
        App.screenLoader.Show<Options>();
    }
    public void Quit()
    {
        Application.Quit();
    }
    IEnumerator Transition()
    {
        transition.SetTrigger("end");
        yield return new WaitForSeconds(2);
        App.loader.UnloadScene("Menu");
        App.loader.LoadScene("Coins collecting", true);
    }
}
