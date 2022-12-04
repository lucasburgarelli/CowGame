using UnityEngine;
using UnityEngine.SceneManagement;

public class UiMainMenu : MonoBehaviour
{
    public void OnButtonLevelsClick()
    {
        SceneManager.LoadScene("UILevels");
    }

    public void OnButtonPlayerControls()
    {
        SceneManager.LoadScene("UIPlayerControls");
    }
    
    public void OnButtonExitClick()
    {
        Application.Quit();
    }
}
