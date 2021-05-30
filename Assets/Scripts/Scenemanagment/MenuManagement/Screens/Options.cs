using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : BaseScreen
{
    public void Back()
    {
        Hide();
        App.screenLoader.Show<Main>();
    }
}
