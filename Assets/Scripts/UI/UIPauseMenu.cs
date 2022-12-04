using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPauseMenu : MonoBehaviour
{
    public void OnButtonContinueClick()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
