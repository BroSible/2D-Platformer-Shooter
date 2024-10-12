using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealHeartScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(!UpgradeMenu.UpgradedHealth)
            {
                if(PlayerHP.health < PlayerHP.MaxHealth)
                {
                    PlayerHP.health += 20f;
                    Destroy(gameObject);
                }
            }
                    
            else
            {
                if(PlayerHP.health < PlayerHP.MaxHealth)
                {
                    PlayerHP.health += 20f;
                    Destroy(gameObject);
                }
            }
        }
    }
}
