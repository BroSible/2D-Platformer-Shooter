using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool filedeleted = false;
    public GameObject MainMenuUI;
    public GameObject SettingMenuUI;

    void Start()
    {
        
    }
    
    void Update()
    {
       Time.timeScale = 1f; 
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void StartButton()
    {
        if(filedeleted && !File.Exists(Storage.filePath))
        {
            SceneManager.LoadScene(1);
        }

        else
        {
            SceneManager.LoadScene(Example.currentIndex);
        }
        
        Time.timeScale = 1f;
    }

    public void SettingMenu()
    {
        MainMenuUI.SetActive(false);
        SettingMenuUI.SetActive(true);

    }

    public void BackButton()
    {
        MainMenuUI.SetActive(true);
        SettingMenuUI.SetActive(false);
    }

    public void DeleteSaveFileButton()
    {
        if (File.Exists(Storage.filePath))
        {
            File.Delete(Storage.filePath);
            Debug.Log("Файл сохранения удален.");
            filedeleted = true;
        }
        else
        {
            Debug.Log("Файл сохранения не существует.");
            filedeleted = true;
        }
    }
}
