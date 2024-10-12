using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class UpgradeMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject UpgradeMenuUI;
    public GameObject CollectablesUI;
    public static bool UpgradedHealth = false;
    public static bool UpgradedWeapon = false;
    public static bool UpgradedRateOfFire = false;
    public Text errorText;

    IEnumerator ErrorTextActive()
    {
        yield return new WaitForSeconds(0.2f);
        errorText.text = " ";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
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
        UpgradeMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        CollectablesUI.SetActive(true);
    }

    public void Pause()
    {
        UpgradeMenuUI.SetActive(true);
        CollectablesUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void UpgradeHealth()
    {
        if(MoneyText.Coin >= 80)
        {
            PlayerHP.MaxHealth += 20f;
            MoneyText.Coin -= 80;
            UpgradedHealth = true;
        }
        
        else
        {
            errorText.text = "Not enough coins";
            StartCoroutine(ErrorTextActive());
        }
    }

    public void UpgradeWeapon()
    {
        if(MoneyText.Coin >= 100)
        {
            BulletScript.timeToDeleteBullet += 0.5f;
            MoneyText.Coin -= 100;
            UpgradedWeapon = true;
            errorText.text = "Upgrade successful";
            StartCoroutine(ErrorTextActive());
        }  

        else
        {
            errorText.text = "Not enough coins";
            StartCoroutine(ErrorTextActive());
        } 
    }

    public void UpgradeRateOfFire()
    {
        if(MoneyText.Coin >= 150)
        {
            Shoot.timeBetweenShots -= 0.1f;
            PlayerAmmo.timeBetweenShots -= 0.1f;
            MoneyText.Coin -= 150;
            UpgradedRateOfFire = true;
            errorText.text = "Upgrade successful";
            StartCoroutine(ErrorTextActive());
        }

        else
        {
            errorText.text = "Not enough coins";
            StartCoroutine(ErrorTextActive());
        }
        
    }
}
