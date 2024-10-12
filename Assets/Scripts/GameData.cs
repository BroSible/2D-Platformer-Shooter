using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System;

[Serializable]
public class GameData 
{
    public Vector3 position;
    public Quaternion rotation;
    public bool facingright;
    public int currentIndex;
    public int Coin;
    public float health;
    public int ammo;
    public bool UpgradedHealth;
    public bool UpgradedWeapon;
    public bool UpgradedRateOfFire;
    public float MaxHealth;
    public bool gameSaved;
    public bool filedeleted;
    
    public GameData()
    {
        position = Vector3.up;
        rotation = Quaternion.identity;
        facingright = true;
        gameSaved = false;
        health = 100f;
        ammo = 30;
        Coin = 0;
        MaxHealth = 100f;
        UpgradedHealth = false;
        UpgradedWeapon = false;
        UpgradedRateOfFire = false;
        currentIndex = 1;
    }
}
