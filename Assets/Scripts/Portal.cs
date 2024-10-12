using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public Animator animator;
    public int levelToLoad;
    IEnumerator LoadingLevel()
    {   
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelToLoad);
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void FadeToLevel()
    {
        animator.SetTrigger("fade");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.Play("fadeOut"); 
            StartCoroutine(LoadingLevel());
        }
    }

}
