using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using UnityEngine.SceneManagement;

public class Example : MonoBehaviour
{
    public GameObject cube;
    private Storage storage;
    private GameData gameData;
    public static int currentIndex = 2;
    public static float health;
    public Animator animator;
    public GameObject SaveMessage;
    public static bool UpgradedHealth;
    public static bool UpgradedWeapon;
    public static bool UpgradedRateOfFire;
    public static float MaxHealth;
    public static bool gameSaved = false;
    public static bool filedeleted;
     

    IEnumerator SetActiveMessage()
    {
        yield return new WaitForSeconds(1f);
        SaveMessage.SetActive(false);
    } 
 
    void Start()
    {
        storage = new Storage();
        gameData = new GameData();
        animator = GetComponent<Animator>();
        Load(); 
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("CheckPoint"))
        {
            Save();
            SaveMessage.SetActive(true);
            StartCoroutine(SetActiveMessage());
            Debug.Log("Player compare with CheckPoint");
        }
    }

    void Update()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
            SceneManager.LoadScene(currentIndex);
        }
    }

    public void Save()
    {
        gameData.position = cube.transform.position;
        gameData.rotation = cube.transform.rotation;
        gameData.currentIndex = currentIndex; 
        gameData.facingright = cube.GetComponent<PlayerController2D>().facingright;
        gameData.Coin = MoneyText.Coin;
        gameData.health = PlayerHP.health;
        gameData.ammo = PlayerAmmo.ammo;
        gameData.filedeleted = MainMenu.filedeleted;
        gameData.MaxHealth = PlayerHP.MaxHealth;
        gameData.gameSaved = Example.gameSaved;
        gameData.UpgradedWeapon = UpgradeMenu.UpgradedWeapon;
        gameData.UpgradedHealth = UpgradeMenu.UpgradedHealth;
        gameData.UpgradedRateOfFire = UpgradeMenu.UpgradedRateOfFire;
        storage.Save(gameData);
        Debug.Log("Индекс уровня при сохранении: " + gameData.currentIndex);
    }

    public void Load()
    {
        gameData = (GameData)storage.Load(new GameData());
        cube.transform.position = gameData.position;
        cube.transform.rotation = gameData.rotation;
        cube.GetComponent<PlayerController2D>().facingright = gameData.facingright;
        MoneyText.Coin = gameData.Coin;
        PlayerHP.health = gameData.health;
        PlayerAmmo.ammo = gameData.ammo;
        MainMenu.filedeleted = gameData.filedeleted;
        Example.currentIndex = gameData.currentIndex;       
        UpgradeMenu.UpgradedHealth = gameData.UpgradedHealth;
        UpgradeMenu.UpgradedWeapon = gameData.UpgradedWeapon;
        UpgradeMenu.UpgradedRateOfFire = gameData.UpgradedRateOfFire;
        PlayerHP.MaxHealth = gameData.MaxHealth;
        Example.gameSaved = gameData.gameSaved;
        Debug.Log("Индекс уровня при загрузке: " + Example.currentIndex);
    }
}
