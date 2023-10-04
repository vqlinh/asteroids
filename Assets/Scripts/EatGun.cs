using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class EatGun : MonoBehaviour
{
   
    public float speed = 5f;


    void Start()
    {
        Hide();
    }

  

    void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

  
}