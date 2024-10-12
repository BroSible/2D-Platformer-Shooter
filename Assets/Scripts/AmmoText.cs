using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour
{
    public static float ammo;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }
    
    void Update()
    {
        text.text = ammo.ToString();
    }
}
