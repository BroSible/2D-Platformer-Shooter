using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    public static float health;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

  
    void Update()
    {
        text.text = health.ToString();
    }
}
