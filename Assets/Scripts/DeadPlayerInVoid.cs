using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadPlayerInVoid : MonoBehaviour
{  
    public int currentIndex;
    
    void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
           Destroy(gameObject); 
           SceneManager.LoadScene(currentIndex);
        }
    }
}
