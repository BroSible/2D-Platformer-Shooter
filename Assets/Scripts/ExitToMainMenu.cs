using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMainMenu : MonoBehaviour
{
    public void ExitToMainMenul()
    {
        SceneManager.LoadScene(0);
    }
}
