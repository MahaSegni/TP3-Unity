using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemies : MonoBehaviour
{
    public Image image;
    public float health;
    public float maxHealth;
    public bool IsDead => health <= 0;
    void Start()
    {
 
        health = maxHealth;
    }

    
    public void TakeDamage(int damage)
    {
        
        health -= damage;
        if (IsDead)
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = health / maxHealth;
    }

    public void Init(float healthModifier)
    {
        health += healthModifier;
    }
   
}