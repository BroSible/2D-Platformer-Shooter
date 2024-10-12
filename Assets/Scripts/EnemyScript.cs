using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float timeBetweenShots = 0.3f; 
    private float timeSinceLastShot = 0f; 
    bool isShoot = false;
    public Transform shootingPoint;
    GameObject bulletRef;
    public GameObject bullet;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    [SerializeField] public GameObject blood;
    Animator animator;
    public float health = 100f;
    private float timeToDeleteBody = 0.2f;
    private float timeToDie = 0f; 
    [SerializeField] public bool isHeating = false;
    [SerializeField] public bool isDead = false;
    [SerializeField] public  bool facingrightEnemy = true;
    [SerializeField] Transform ShootPointEnemy;

    //*******************************************
    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float shootRange;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    Transform CastPoint;
    public bool isPlayerInside = false;
    [SerializeField]
    public Transform targetTransform;
    public AudioSource shootSoundEnemy;
   
    IEnumerator BloodCoroutine()
    {   
        yield return new WaitForSeconds(0.7f);
        blood.SetActive(false);
    }

    IEnumerator Heating()
    {
        yield return new WaitForSeconds(1f);
        isHeating = false;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        blood.SetActive(true);
        StartCoroutine(BloodCoroutine());
        isHeating = true;
        if(health <= 0)
        {
            isDead = true;
            animator.Play("Player_Dead2");
            MoneyText.Coin += 5;
        }  
    }

    void flipEnemy()
    {
        facingrightEnemy = !facingrightEnemy;
        transform.Rotate(0f,180f,0f);
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        bulletRef = Resources.Load<GameObject>("Bullet1"); 
    }

    void FixedUpdate()
    {
        if(isDead)
        {
            timeToDie += Time.deltaTime;
        }

        if(timeToDie >= timeToDeleteBody)
        { 
            Destroy(gameObject);  
        }   
    }

    void Update()
    {
        if(CanSeePlayer(agroRange))
        {
            if(!isShoot)
            {
                ChasePlayer();
            }
            CanShotPlayer(shootRange);    
        }

        else
        {
            StopChasingPlayer();
        }  
    }

    bool CanSeePlayer(float distance)
    {
        bool val = false;
        float castDist = -distance;

        Vector2 endPosition = targetTransform.position;
        Vector2 endPos = CastPoint.position + Vector3.right * distance;

        if (!facingrightEnemy)
        {
           endPos = CastPoint.position - Vector3.right * distance; //Изменили направление луча
        }
        RaycastHit2D hit = Physics2D.Linecast(CastPoint.position, endPos, 1 << LayerMask.NameToLayer("Player"));


        if(hit.collider != null)
        {
            if(hit.collider.gameObject.CompareTag("Player"))
            {
                val = true;
            }

            else
            {
                val = false;
            }
            Debug.DrawLine(CastPoint.position, endPos, Color.blue);
        }
        
        else
        {
            Debug.DrawLine(CastPoint.position, endPos, Color.blue);
        }

        if(isHeating)
        {
            StartCoroutine(Heating());
            hit = Physics2D.Linecast(CastPoint.position, endPosition, 1 << LayerMask.NameToLayer("Player"));
            if(hit.collider.gameObject.CompareTag("Player"))
            {
                val = true;
            }

            else
            {
                val = false;
            }
            Debug.DrawLine(CastPoint.position, endPos, Color.blue);
        }

        return val;
    }

    void CanShotPlayer(float shotDistance)
    {
        float castDist = -shotDistance;

        Vector2 endPos = ShootPointEnemy.position + Vector3.right * shotDistance;
        if(!facingrightEnemy)
        {
            endPos = ShootPointEnemy.position - Vector3.right * shotDistance;
        }
        RaycastHit2D hit1 = Physics2D.Linecast(ShootPointEnemy.position, endPos, 1 << LayerMask.NameToLayer("Player"));

        if(hit1.collider != null)
        {
            if(hit1.collider.gameObject.CompareTag("Player"))
            {
                isShoot = true;
                Shoot();
            }

            else 
            {
                isShoot = false;
            }
            Debug.DrawLine(ShootPointEnemy.position, endPos, Color.red);
        }
        
        else
        {
            isShoot = false;
            Debug.DrawLine(ShootPointEnemy.position, endPos, Color.red);
        }   
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            ChasePlayer();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            StopChasingPlayer();
        }
    }

    void Shoot()
    {
        timeSinceLastShot += Time.deltaTime;
        animator.Play("Enemy_Shot"); 
        if(timeSinceLastShot >= timeBetweenShots)
        {
            Instantiate(bullet,shootingPoint.position,transform.rotation);
            shootSoundEnemy.Play();
            timeSinceLastShot = 0;
        }
    }
    
    void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed,0);
            if(!isDead && !isShoot)
            {
                animator.Play("Enemy_Walk");
            }

            if(!facingrightEnemy)
            {
                flipEnemy();
            }          
        }

        else
        {
            rb2d.velocity = new Vector2(-moveSpeed,0);
            if(!isDead && !isShoot)
            {
                animator.Play("Enemy_Walk");
            }
            if(facingrightEnemy)
            {
                flipEnemy();
            } 
        }
    }

    void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0,0);
        if(!isDead)
        {
            animator.Play("nps_Idle");
        }
    }
}