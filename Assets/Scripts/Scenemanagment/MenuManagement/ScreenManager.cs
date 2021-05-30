using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    private BaseScreen [] screens;
    private void Awake()
    {
        App.screenLoader = this;
        screens = GetComponentsInChildren<BaseScreen>(true);
    }
    public void Show<A>()
    {
        foreach(BaseScreen screen in screens)
        {
            if(screen.GetType()==typeof(A))
            {
                screen.Show();
            }
        }
    }
    public void Hide<A>()
    {
        foreach (BaseScreen screen in screens)
        {
            if (screen.GetType() == typeof(A))
            {
                screen.Hide();
            }
        }
    }
}
