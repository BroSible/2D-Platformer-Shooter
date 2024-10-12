using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject settingMenuUI;
    
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
       {
            if(GameIsPaused)
            {
                Resume();
            }

            else
            {
                Pause();
            }
       } 
    }
    
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        settingMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void BackToPauseMenu()
    {
        settingMenuUI.SetActive(false);
        PauseMenuUI.SetActive(true);
    }

    public void SettingMenu()
    {
       settingMenuUI.SetActive(true);
       PauseMenuUI.SetActive(false);
    }

    public void QuitMenu()
    {
        Debug.Log("Quit");
        SceneManager.LoadScene("MainMenu");
    }
}
