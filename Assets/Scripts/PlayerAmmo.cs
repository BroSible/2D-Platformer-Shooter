using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmmo : MonoBehaviour
{
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    Animator animator;
    public static float timeBetweenShots = 0.3f; 
    public float timeSinceLastShot = 0f;

    public bool isShooting = false;
    public static int ammo = 30;

    IEnumerator MinusAmmo()
    {
        yield return new WaitForSeconds(0.3f);
        isShooting = false;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        AmmoText.ammo = ammo;
    }

    void FixedUpdate()
    {
        timeSinceLastShot += Time.deltaTime;
        if(Input.GetButton("Fire1"))
        {
            isShooting = true;
            StartCoroutine(MinusAmmo());
        }

        if(isShooting)
        {
            if(timeSinceLastShot >= timeBetweenShots)
            {
                ammo--;
                timeSinceLastShot = 0;
            }
            if(ammo<=0)
            {
                ammo = 0;
            }
            AmmoText.ammo = ammo;
        }
    }
}
