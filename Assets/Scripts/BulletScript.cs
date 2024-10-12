using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    public static float timeToDeleteBullet = 1f;
    public float timeToDelete = 0f;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.right * speed;         
    }

    private void Update()
    {
        timeToDelete += Time.deltaTime;
        if(timeToDelete >= timeToDeleteBullet)
        {
            DestroySelf();
        }
    }
    
    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyScript enemy = collision.GetComponent<EnemyScript>();
        PlayerHP player = collision.GetComponent<PlayerHP>();

        if(enemy != null)
        {
            enemy.TakeDamage(20);
        }

        if(player != null)
        {
            player.TakeDamage(20);
        }
        DestroySelf();
    }   
}

