using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform shootingPoint;
    GameObject bulletRef;
    public GameObject bullet;
    public static float timeBetweenShots = 0.3f; 
    public float timeSinceLastShot = 0f; 
    SpriteRenderer spriteRenderer;
    Animator animator;
    public AudioSource shootSound;
    public AudioSource reloadSound;
    public AudioSource FonMusic;
    public static bool reloading = false;
   
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(0.8f);
        PlayerAmmo.ammo = 30;
        AmmoText.ammo = PlayerAmmo.ammo;
        reloading = false;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        bulletRef = Resources.Load<GameObject>("Bullet1");
        FonMusic.Play();
    }

 
    void FixedUpdate()
    {
        timeSinceLastShot += Time.deltaTime;
        if(PlayerAmmo.ammo > 0)
        {
            if(Input.GetButton("Fire1"))
            {
                PlayerController2D.isShooting = true;
                if(!UpgradeMenu.UpgradedWeapon)
                {
                    animator.Play("Player_Shot2"); 
                }

                else
                {
                    animator.Play("Player_ShotUpgraded");
                }
               
                if(timeSinceLastShot >= timeBetweenShots)
                {
                    Instantiate(bullet,shootingPoint.position,transform.rotation);
                    shootSound.Play();
                    timeSinceLastShot = 0;
                }
            }

            else if(Input.GetKey("r") && PlayerAmmo.ammo != 30)
            {
                StartCoroutine(Reload());
                reloading = true;
                reloadSound.Play();
                if(!UpgradeMenu.UpgradedWeapon)
                {
                    animator.Play("Player_Reload"); 
                }
                
                else
                {
                    animator.Play("Player_ReloadUpgraded");
                }   
            }
        
            else
            {
                PlayerController2D.isShooting = false; 
            }
        }
        
        else
        {
            StartCoroutine(Reload());
            reloading = true;
            reloadSound.Play();
            if(!UpgradeMenu.UpgradedWeapon)
                {
                    animator.Play("Player_Reload"); 
                }
                
                else
                {
                    animator.Play("Player_ReloadUpgraded");
                }   
        }
    }
}
