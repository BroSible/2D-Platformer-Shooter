using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    Animator animator;
    public static float health = 100f;
    public static float MaxHealth = 100f;
    public static float OverMaxHealth = 200f;
    private float timeToDeleteBody = 0.1f;
    private float timeToDie = 0f;
    [SerializeField] public bool isDead = false;
    [SerializeField] public GameObject bloodPlayer;
    int currentIndex;

    IEnumerator BloodCoroutinePlayer()
    {   
        yield return new WaitForSeconds(0.7f);
        bloodPlayer.SetActive(false);
    } 

    public void TakeDamage(float damage)
    {
        health -= damage;
        bloodPlayer.SetActive(true);
        StartCoroutine(BloodCoroutinePlayer());
        if(health <= 0)
        {
            PlayerAmmo.ammo = 30;
            MoneyText.Coin = 0;
            animator.Play("Player_Dead2");
            isDead = true;
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        HealthText.health = health;
        currentIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void FixedUpdate()
    {
        HealthText.health = health;
        if(isDead)
        {
            timeToDie += Time.deltaTime;
        }

        if(timeToDie >= timeToDeleteBody)
        {
            Destroy(gameObject);   
            SceneManager.LoadScene(currentIndex);
        }        
    }
}
