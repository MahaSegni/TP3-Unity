using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;


public class Manager : MonoBehaviour
{
    public TMP_Text ClicksTotalText;

    public bool hasUpgraded;
    public float TotalClicks;
    public int autoClicksPerSecond;
    public int minimumMoneyToUnlockUpgrade;
    public float Money;
    public TMP_Text Moneytext;
    public float TotalMoney;
    public Enemies enemiesPrefab;
    public Enemies currentEnemy;
    public TMP_Text levelText;
    private int levelIncrement;
    public Transform spawnPosition;
    public bool IsDead => currentEnemy.health <= 0;

    public Image imageOnScene;
    public int counterSpawn;

    private void Start()
    {
        
    }

    public void AddClicks(){

        TotalClicks++;
        TotalMoney++;
        ClicksTotalText.text = $"Clicks:  {TotalClicks}";

        Money += 20f;
        Moneytext.text = $"Argent: {Money}";

    }
    
    public void OnBackgroundClicked()
    {
        if (currentEnemy != null)
        {
            currentEnemy.TakeDamage(10);
            if (currentEnemy.IsDead)
            {
                levelIncrement++;
                counterSpawn++;
                Money += 20f;
                
                levelText.text = $"Niveau: {levelIncrement}";
                Vector3 spawnPos = new Vector3(10, 10, 10);
                spawnEnemy(spawnPos);
          
            }
        }
    }

    void spawnEnemy(Vector3 size)
    {

        Vector3 specificPosition = new Vector3(8, 8, 8);
        if(counterSpawn >= 5 ) return;
        
        currentEnemy = Instantiate(enemiesPrefab, new Vector3(377,13,80), Quaternion.identity);
        currentEnemy.transform.localScale = size;
        currentEnemy.Init(30);
        currentEnemy.image = imageOnScene;
    }

      private void AutoClickUpdate(){
        minimumMoneyToUnlockUpgrade = 30;
         if(!hasUpgraded && Money >= minimumMoneyToUnlockUpgrade){
            Debug.Log("Upgrade autoclick ");
            //TotalClicks = 5;
            Money -= minimumMoneyToUnlockUpgrade;
            hasUpgraded = true;
            
        } 
    }    

    private void Update(){

        if(Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
        ClicksTotalText.text = $"Clicks: " + TotalClicks.ToString();
        Moneytext.text = $"Argent: " + Money.ToString();
        levelText.text = $"Niveau: {levelIncrement}";

        if(hasUpgraded){
            //autoClicksPerSecond = 3;
            Debug.Log("Upgrade if update  ");
            TotalClicks += autoClicksPerSecond * Time.deltaTime;
            //TotalMoney+= autoClicksPerSecond * Time.deltaTime;
            ClicksTotalText.text = TotalClicks.ToString("0");
            Moneytext.text = Money.ToString("0");
            currentEnemy.TakeDamage(10);
            hasUpgraded = false;
            
        }
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("Money", Money);
        PlayerPrefs.SetFloat("TotalClicks", TotalClicks);
    }

    private void Load()
    {
        Money = PlayerPrefs.GetFloat("Money", 0);
        TotalClicks = PlayerPrefs.GetFloat("TotalClicks", 0);
        
    }

}