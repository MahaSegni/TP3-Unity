using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Image image;
    public float health;
    public float maxHealth;
    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(2) && GameObject.FindGameObjectWithTag("enemies"))
        {
            TakeDamage(10);
           // Debug.Log(health);
        }
        //image.fillAmount = health / maxHealth;
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        health = health - damage;
    }
    
    
     
}