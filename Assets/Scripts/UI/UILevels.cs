using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILevels : MonoBehaviour
{
    public void OnButtonLevel1Click()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnButtonLevel2Click()
    {
        SceneManager.LoadScene("Level2");
    }

    public void OnButtonLevel3Click()
    {
        SceneManager.LoadScene("Level3");
    }

    public void OnButtonExitClick()
    {
        SceneManager.LoadScene("UIMainMenu");
    }
}
